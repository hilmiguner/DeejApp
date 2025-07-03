import asyncio
import websockets
from typing import Set
from utility import Utility
import sys
from serial_asyncio import SerialTransport

class WebSocketServer:
    def __init__(self):
        self.clients:Set[websockets.ServerConnection]  = set()
        self.serialTransport: SerialTransport = None

    async def handler(self, websocket: websockets.ServerConnection):
        self.clients.add(websocket)
        Utility.log(f"[WebSocket] New connection: {websocket.remote_address}")
        try:
            async for msg in websocket:
                pass
        finally:
            self.clients.remove(websocket)
            Utility.log(f"[WebSocket] Disconnected: {websocket.remote_address}")
            self.serialTransport.close()
            sys.exit()

    async def start(self, port=8765):
        Utility.log(f"[WebSocket] Server is starting...")
        return await websockets.serve(self.handler, "localhost", port)

    async def broadcast(self, message):
        if self.clients:
            await asyncio.gather(*[client.send(message) for client in self.clients])

    
