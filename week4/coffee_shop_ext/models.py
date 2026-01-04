from dataclasses import dataclass, field
from typing import List


@dataclass(frozen=True)
class Beverage:
    name: str
    price: float

    def describe(self) -> str:
        return f"{self.name} - ${self.price:.2f}"


@dataclass(frozen=True)
class Coffee(Beverage):
    roast: str

    def describe(self) -> str:
        return f"{self.name} ({self.roast}) - ${self.price:.2f}"


@dataclass(frozen=True)
class Tea(Beverage):
    origin: str

    def describe(self) -> str:
        return f"{self.name} from {self.origin} - ${self.price:.2f}"


@dataclass
class Order:
    items: List[Beverage] = field(default_factory=list)

    def add_item(self, item: Beverage) -> None:
        self.items.append(item)

    def total(self) -> float:
        return sum(item.price for item in self.items)

    def summary(self) -> str:
        lines = [item.describe() for item in self.items]
        lines.append(f"Total: ${self.total():.2f}")
        return "\n".join(lines)


@dataclass
class CoffeeShop:
    name: str
    menu: List[Beverage]

    def create_order(self) -> Order:
        return Order()

    def find_item(self, item_name: str) -> Beverage | None:
        for item in self.menu:
            if item.name.lower() == item_name.lower():
                return item
        return None
