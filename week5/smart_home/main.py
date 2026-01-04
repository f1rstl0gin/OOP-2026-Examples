from models import Room, SmartHub, SmartLight, SmartSpeaker


def build_demo_home() -> SmartHub:
    living_room = Room("Living Room")
    living_room.add_device(SmartLight("Ceiling Light", brightness=80))
    living_room.add_device(SmartSpeaker("Sound Bar", volume=45))

    bedroom = Room("Bedroom")
    bedroom.add_device(SmartLight("Bedside Lamp", brightness=20))

    hub = SmartHub()
    hub.add_room(living_room)
    hub.add_room(bedroom)
    return hub


def main() -> None:
    hub = build_demo_home()
    print(hub.report())


if __name__ == "__main__":
    main()
