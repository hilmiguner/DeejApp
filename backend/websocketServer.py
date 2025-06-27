import asyncio
import websockets
from typing import Set

class WebSocketServer:
    def __init__(self):
        self.clients:Set[websockets.ServerConnection]  = set()

    async def handler(self, websocket: websockets.ServerConnection):
        self.clients.add(websocket)
        print(f"[WebSocket] Yeni bağlantı: {websocket.remote_address}")
        try:
            async for _ in websocket:
                pass
        finally:
            self.clients.remove(websocket)
            print(f"[WebSocket] Bağlantı kapandı: {websocket.remote_address}")

    async def start(self, port=8765):
        print(f"[WebSocket] Sunucu başlatılıyor...")
        return await websockets.serve(self.handler, "localhost", port)

    async def broadcast(self, message):
        if self.clients:
            await asyncio.gather(*[client.send(message) for client in self.clients])
