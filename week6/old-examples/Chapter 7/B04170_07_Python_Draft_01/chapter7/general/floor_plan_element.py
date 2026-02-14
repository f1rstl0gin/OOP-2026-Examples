__author__ = 'gaston'


class FloorPlanElement:
    category = "Undefined"
    description = "Undefined"

    def __init__(self, x, y, width, height, parent):
        self.x = x
        self.y = y
        self.width = width
        self.height = height
        self.parent = parent

    def move_to(self, x, y):
        self.x = x
        self.y = y

    def print_category(self):
        print(type(self).category)

    def print_description(self):
        print(type(self).description)

    def draw(self):
        self.print_category()
        self.print_description()
        print("X: " + str(self.x) +
              ", Y: " + str(self.y) +
              ". Width: " + str(self.width) +
              ", Height: " + str(self.height) + ".")
