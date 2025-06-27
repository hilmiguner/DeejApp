from pycaw.pycaw import AudioUtilities, IAudioEndpointVolume
from pycaw.utils import AudioDevice
from pycaw.constants import DEVICE_STATE, EDataFlow
from ctypes import cast, POINTER
from comtypes import CLSCTX_ALL
from serialPort import SerialPort
from utility import Utility
import time

class DeejApp:
    def __init__(self):
        self.serialPort = SerialPort()
        self.portName = self.serialPort.findPort()

    def setMasterVolume(self, value):
        speakerDevice = AudioUtilities.GetSpeakers()
        interface = speakerDevice.Activate(IAudioEndpointVolume._iid_, CLSCTX_ALL, None)
        volume = cast(interface, POINTER(IAudioEndpointVolume))
        volume.SetMasterVolumeLevelScalar(value, None)

    def setMicrophoneVolume(self, value):
        micDevice = AudioUtilities.GetMicrophone()
        interface = micDevice.Activate(IAudioEndpointVolume._iid_, CLSCTX_ALL, None)
        volume = cast(interface, POINTER(IAudioEndpointVolume))
        volume.SetMasterVolumeLevelScalar(value, None)

    def toggleMuteMasterVolume(self, buttonVal: str):
        speakerDevice = AudioUtilities.GetSpeakers()
        interface = speakerDevice.Activate(IAudioEndpointVolume._iid_, CLSCTX_ALL, None)
        volume = cast(interface, POINTER(IAudioEndpointVolume))
        if "MUTE_ON" in buttonVal and not volume.GetMute():
            volume.SetMute(True, None)
        elif "MUTE_OFF" in buttonVal and volume.GetMute():
            volume.SetMute(False, None)

    def toggleMuteMicrophone(self, buttonVal: str):
        micDevice = AudioUtilities.GetMicrophone()
        interface = micDevice.Activate(IAudioEndpointVolume._iid_, CLSCTX_ALL, None)
        volume = cast(interface, POINTER(IAudioEndpointVolume))
        if "MUTE_ON" in buttonVal and not volume.GetMute():
            volume.SetMute(True, None)
        elif "MUTE_OFF" in buttonVal and volume.GetMute():
            volume.SetMute(False, None)

    def startApp(self):
        if self.portName is None:
            return
        
        self.serialPort.openSerialPort(self.portName, 9600)
        if not hasattr(self.serialPort, "ser"):
            return
        while True:
            try:
                if self.serialPort.ser.in_waiting:
                    line = self.serialPort.ser.readline().decode('utf-8', errors='ignore')
                    data = Utility.parseInputData(line)
                    if data:
                        slider1 = Utility.normalize(data[0], out_max=1)
                        slider2 = Utility.normalize(data[1], out_max=1)
                        button1 = data[2]
                        button2 = data[3]

                        self.setMasterVolume(slider1)
                        self.setMicrophoneVolume(slider2)
                        
                        self.toggleMuteMasterVolume(button1)
                        self.toggleMuteMicrophone(button2)

            except KeyboardInterrupt:
                print("Program sonlandırıldı.")
                break
            except Exception as e:
                print(f"Hata: {e}")

if __name__ == "__main__":
    app = DeejApp()
    app.startApp()