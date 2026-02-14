__author__ = 'gaston'


from general.floor_plan_element import FloorPlanElement


class Door(FloorPlanElement):
    category = "Door"


class EntryDoor(Door):
    description = "Entry Door"
