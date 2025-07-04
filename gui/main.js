import { app, BrowserWindow, ipcMain } from 'electron';
import { dirname, join } from 'path';
import { spawn } from 'child_process';
import isDev from 'electron-is-dev';
import { fileURLToPath } from 'url';

const __filename = fileURLToPath(import.meta.url);
const __dirname = dirname(__filename);

let win = null;

function createWindow() {
  win = new BrowserWindow({
    width: 400,
    height: 500,
    webPreferences: {
      nodeIntegration: true,
      contextIsolation: false,
    }
  });

  const exeDir = dirname(app.getPath('exe'));
  const backendPath = isDev ? join(__dirname, '../backend/dist/deej-backend.exe') : join(exeDir, 'resources/deej-backend.exe');

  let backendProcess = spawn(backendPath, [], { stdio: ['pipe', 'pipe', 'pipe'] });

  backendProcess.stdout.on('data', (data) => {
    if (data.toString().includes("WebSocket server has been started.")) {
      win.loadFile("gui/index.html");
    }
    console.log(`[Electron] Backend stdin: ${data.toString("utf8")}`);
  });

  backendProcess.stderr.on('data', (data) => {
    if(!data.toString().includes("SystemExit")) {
      console.error(`[Electron] Backend error: ${data.toString("utf8")}`);
    }
  });

  backendProcess.on('close', (code, signal) => {
    console.log(`[Electron] Backend has been closed (kod: ${code}) (signal: ${signal})`);
  });
}

async function checkForUpdate() {
  try {
    const response = await fetch("https://hilmiguner.github.io/deejapp-updates/version.json");
    const data = await response.json();

    const currentVersion = app.getVersion();
    const latestVersion = data.latest_version;

    if (currentVersion !== latestVersion) {
      console.log("[Electron] App isn't up to date. Starting updating process...");
      win.webContents.once('did-finish-load', () => {
        win.webContents.send('update-available', {
          currentVersion,
          latestVersion,
          releaseNotes: data.release_notes,
          downloadUrl: data.download_url
        });
      });
    }
    else {
      console.log("[Electron] App is up to date.");
    }
  } catch (err) {
    console.warn("[Electron] Version check failure:", err.message);
  }
}

ipcMain.on('exit-app', () => {
  console.log("[Electron] Updating process started, app is shutting down.");
  app.quit();
});

app.whenReady().then(() => {
  createWindow();
  checkForUpdate();
});

app.on('window-all-closed', () => {
  setTimeout(() => {
    if (process.platform !== 'darwin') {
      app.quit();
    }
  }, 3000);
});
