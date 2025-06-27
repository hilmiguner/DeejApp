const ws = new WebSocket('ws://localhost:8765');

ws.onopen = () => {
  console.log("WebSocket bağlantısı kuruldu.");
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
  console.log("WebSocket bağlantısı kapandı.");
};