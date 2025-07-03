const { app, BrowserWindow } = require('electron');
const path = require('path');
const { spawn } = require('child_process');
const kill = require('tree-kill');

let win = null;

let backendProcess = null;

function createWindow() {
  win = new BrowserWindow({
    width: 400,
    height: 500,
    webPreferences: {
      nodeIntegration: true,
      contextIsolation: false,
    }
  });

  const backendPath = path.join(__dirname, '../backend/dist/deej-backend.exe');
  backendProcess = spawn(backendPath, [], { stdio: ['pipe', 'pipe', 'pipe'] });

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

app.whenReady().then(createWindow);

app.on('window-all-closed', () => {
  setTimeout(() => {
    kill(backendProcess.pid);
    if (process.platform !== 'darwin') {
      app.quit();
    }
  }, 3000);
});
