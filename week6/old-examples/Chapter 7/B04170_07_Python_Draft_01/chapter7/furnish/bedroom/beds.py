__author__ = 'gaston'

from general.floor_plan_element import FloorPlanElement


class Bed(FloorPlanElement):
    category = "Bed"
    description = "Generic bed"


class FabricBed(Bed):
    description = "Fabric bed"