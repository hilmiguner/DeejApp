import asyncio
import serial.tools.list_ports
import serial_asyncio
from utility import Utility

class SerialHandler(asyncio.Protocol):
    def __init__(self, on_data_callback):
        self.on_data_callback = on_data_callback
        self.buffer = ""
    
    def connection_made(self, transport):
        Utility.log(f"[Serial] Connected: {transport}")
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
            Utility.log(f"[Serial] Reading error: {e}")

    def connection_lost(self, exc):
        Utility.log(f"[Serial] Disconnected: {exc}")


async def find_serial_port_and_device_info(keyword="DEEJ_DEVICE_READY", baudrate=9600, timeout=3):
    ports = serial.tools.list_ports.comports()

    for port in ports:
        try:
            Utility.log(f"[Port Scan] Checking {port.device} ...")
            for _ in range(5):
                reader, writer = await serial_asyncio.open_serial_connection(url=port.device, baudrate=baudrate)
                await asyncio.sleep(2)

                line = await reader.readline()
                text = line.decode('utf-8', errors='ignore').strip()
                Utility.log(f"[Port Scan] Data: {text}")

                if keyword in text:
                    parts = text.split('|')
                    if len(parts) >= 2 and len(parts[1]) == 8:
                        device_id = parts[1]
                        Utility.log(f"[Port Scan] Arduino found: {port.device} | Device ID: {device_id}")
                        return port.device, device_id
                    else:
                        Utility.log(f"[Port Scan] Data is not in the correct form.")
            
                writer.close()
                await writer.wait_closed()

        except Exception as e:
            Utility.log(f"[Port Scan] Error: {port.device} {e}")

        finally:
            writer.close()
            await writer.wait_closed()

    Utility.log("[Port Scan] Couldn't find the Arduino.")
    return None, None

