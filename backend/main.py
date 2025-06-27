import asyncio
from serialPort import SerialHandler, find_serial_port
from websocketServer import WebSocketServer
from utility import Utility
from pycaw.pycaw import AudioUtilities, IAudioEndpointVolume
from ctypes import cast, POINTER
from comtypes import CLSCTX_ALL
import serial_asyncio

class DeejApp:
    def __init__(self):
        self.ws_server = WebSocketServer()

    def setMasterVolume(self, value):
        device = AudioUtilities.GetSpeakers()
        interface = device.Activate(IAudioEndpointVolume._iid_, CLSCTX_ALL, None)
        volume = cast(interface, POINTER(IAudioEndpointVolume))
        volume.SetMasterVolumeLevelScalar(value, None)

    def setMicrophoneVolume(self, value):
        device = AudioUtilities.GetMicrophone()
        interface = device.Activate(IAudioEndpointVolume._iid_, CLSCTX_ALL, None)
        volume = cast(interface, POINTER(IAudioEndpointVolume))
        volume.SetMasterVolumeLevelScalar(value, None)

    def toggleMuteMasterVolume(self, buttonVal: str):
        device = AudioUtilities.GetSpeakers()
        interface = device.Activate(IAudioEndpointVolume._iid_, CLSCTX_ALL, None)
        volume = cast(interface, POINTER(IAudioEndpointVolume))
        if "MUTE_ON" in buttonVal and not volume.GetMute():
            volume.SetMute(True, None)
        elif "MUTE_OFF" in buttonVal and volume.GetMute():
            volume.SetMute(False, None)

    def toggleMuteMicrophone(self, buttonVal: str):
        device = AudioUtilities.GetMicrophone()
        interface = device.Activate(IAudioEndpointVolume._iid_, CLSCTX_ALL, None)
        volume = cast(interface, POINTER(IAudioEndpointVolume))
        if "MUTE_ON" in buttonVal and not volume.GetMute():
            volume.SetMute(True, None)
        elif "MUTE_OFF" in buttonVal and volume.GetMute():
            volume.SetMute(False, None)

    async def start(self):
        port = await find_serial_port()
        if not port:
            return

        await self.ws_server.start()

        def handle_serial_data(line):
            print(f"[Serial] Veri: {line}")
            data = Utility.parseInputData(line)
            if data:
                slider1 = Utility.normalize(data[0])
                slider2 = Utility.normalize(data[1])
                button1 = data[2]
                button2 = data[3]

                self.setMasterVolume(slider1)
                self.setMicrophoneVolume(slider2)
                self.toggleMuteMasterVolume(button1)
                self.toggleMuteMicrophone(button2)

                asyncio.create_task(self.ws_server.broadcast(Utility.createBroadcastJson(slider1, slider2, button1, button2)))  # Electron'a veri gönder

        loop = asyncio.get_running_loop()
        await serial_asyncio.create_serial_connection(loop, lambda: SerialHandler(handle_serial_data), port, baudrate=9600)
        print("[Uygulama] Başlatıldı.")
        await asyncio.Future()  # Sonsuz çalış

if __name__ == "__main__":
    asyncio.run(DeejApp().start())
