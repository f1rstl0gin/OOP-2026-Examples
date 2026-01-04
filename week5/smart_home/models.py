from dataclasses import dataclass, field
from typing import List


@dataclass
class Device:
    name: str

    def status(self) -> str:
        return f"{self.name} is idle"


@dataclass
class SmartLight(Device):
    brightness: int = 50

    def status(self) -> str:
        return f"{self.name} is at {self.brightness}% brightness"


@dataclass
class SmartSpeaker(Device):
    volume: int = 30

    def status(self) -> str:
        return f"{self.name} is at volume {self.volume}"


@dataclass
class Room:
    name: str
    devices: List[Device] = field(default_factory=list)

    def add_device(self, device: Device) -> None:
        self.devices.append(device)

    def summary(self) -> str:
        lines = [f"Room: {self.name}"]
        lines.extend(f"- {device.status()}" for device in self.devices)
        return "\n".join(lines)


@dataclass
class SmartHub:
    rooms: List[Room] = field(default_factory=list)

    def add_room(self, room: Room) -> None:
        self.rooms.append(room)

    def report(self) -> str:
        return "\n\n".join(room.summary() for room in self.rooms)
