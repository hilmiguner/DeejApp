import serial
import time
import serial.tools.list_ports

class SerialPort:
    def __init__(self):
        pass

    def openSerialPort(self, port: str, baud: int):
        try:
            self.ser = serial.Serial(port, baud, timeout=1)
            time.sleep(2)
            print(f"{port} üzerinden veri bekleniyor...")
        except serial.SerialException as e:
            print(f"Port açılamadı: {e}")

    def findPort(self, keyword="DEEJ_DEVICE_READY", baudrate=9600, timeout=3):
        ports = serial.tools.list_ports.comports()
        for port in ports:
            try:
                print(f"Port deneniyor: {port.device}")
                with serial.Serial(port.device, baudrate=baudrate, timeout=timeout) as ser:
                    ser.reset_input_buffer()
                    time.sleep(2.5)
                    for _ in range(5):
                        line = ser.readline().decode('utf-8', errors='ignore').strip()
                        print(f"Gelen: {line}")
                        if keyword in line:
                            print(f"✔ Arduino bulundu: {port.device}")
                            return port.device
            except Exception as e:
                print(f"Hata ({port.device}): {e}")
        print("❌ Uygun Arduino cihazı bulunamadı.")
        return None

