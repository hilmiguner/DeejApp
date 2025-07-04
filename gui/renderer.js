const { ipcRenderer, shell } = require('electron');

ipcRenderer.on('update-available', (event, data) => {
  const confirmUpdate = confirm(
    `Yeni sürüm mevcut!\n\nMevcut: v${data.currentVersion}\nYeni: v${data.latestVersion}\n\n${data.releaseNotes}\n\nGüncellemeyi indirmek ister misiniz?`
  );

  if (confirmUpdate) {
    shell.openExternal(data.downloadUrl).then(() => {
      ipcRenderer.send('exit-app');
      return;
    });
  }
  ipcRenderer.send('exit-app');
});

const ws = new WebSocket('ws://localhost:8765');

ws.onopen = () => {
  console.log("[Electron] Connected to WebSocket server.");
};

ws.onmessage = (event) => {
  const data = JSON.parse(event.data);
  document.getElementById("vol1").textContent = "%"+Math.round(data.masterVolume * 100).toString();
  document.getElementById("vol2").textContent = "%"+Math.round(data.micVolume * 100).toString();
  document.getElementById("mute1").textContent = data.masterMute;
  document.getElementById("mute1").className = data.masterMute;
  document.getElementById("mute2").textContent = data.micMute;
  document.getElementById("mute2").className = data.micMute;
};

ws.onclose = () => {
  console.log("[Electron] Disconnected from WebSocket server.");
};