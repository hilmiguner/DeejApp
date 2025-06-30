import asyncio
import serial.tools.list_ports
import serial_asyncio

class SerialHandler(asyncio.Protocol):
    def __init__(self, on_data_callback):
        self.on_data_callback = on_data_callback
        self.buffer = ""
    
    def connection_made(self, transport):
        print(f"[Serial] Bağlantı kuruldu: {transport}")
        self.transport = transport

    def data_received(self, data):
        try:
            text = data.decode('utf-8', errors='ignore')
            self.buffer += text
            if '\n' in self.buffer:
                lines = self.buffer.split('\n')
                for line in lines[:-1]:
                    self.on_data_callback(line.strip())
                self.buffer = lines[-1]
        except Exception as e:
            print(f"[Serial] Okuma hatası: {e}")

    def connection_lost(self, exc):
        print(f"[Serial] Bağlantı kesildi: {exc}")


async def find_serial_port_and_device_info(keyword="DEEJ_DEVICE_READY", baudrate=9600, timeout=3):
    ports = serial.tools.list_ports.comports()

    for port in ports:
        try:
            print(f"[Port Taraması] {port.device} kontrol ediliyor...")
            for _ in range(5):
                reader, writer = await serial_asyncio.open_serial_connection(url=port.device, baudrate=baudrate)
                await asyncio.sleep(2)

                line = await reader.readline()
                text = line.decode('utf-8', errors='ignore').strip()
                print(f"Gelen: {text}")

                if keyword in text:
                    parts = text.split('|')
                    if len(parts) >= 2 and len(parts[1]) == 8:
                        device_id = parts[1]
                        print(f"✔ Arduino bulundu: {port.device} | Cihaz Kodu: {device_id}")
                        return port.device, device_id
                    else:
                        print(f"[Uyarı] Cihaz ID'si ayrıştırılamadı.")
            
                writer.close()
                await writer.wait_closed()

        except Exception as e:
            print(f"[Hata - {port.device}] {e}")

        finally:
            writer.close()
            await writer.wait_closed()

    print("❌ Uygun Arduino cihazı bulunamadı.")
    return None, None

