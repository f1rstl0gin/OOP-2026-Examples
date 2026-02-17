__author__ = 'gaston'


'''from general.floor_plan_element import FloorPlanElement
'''
import general.floor_plan_element


class Room(general.floor_plan_element.FloorPlanElement):
    category = "Room"


class SquareRoom(Room):
    description = "Square room"

    def __init__(self, x, y, width, parent):
        super().__init__(x, y, width, width, parent)


class LShapedRoom(Room):
    description = "L-Shaped room"


class SmallRoom(Room):
    description = "Small room"


class Closet(Room):
    description = "Closet"
