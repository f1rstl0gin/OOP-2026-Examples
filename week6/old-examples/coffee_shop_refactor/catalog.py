from dataclasses import dataclass
from typing import Iterable, List


@dataclass(frozen=True)
class Beverage:
    name: str
    price: float

    def display(self) -> str:
        return f"{self.name} - ${self.price:.2f}"


class Menu:
    def __init__(self, items: Iterable[Beverage]) -> None:
        self._items: List[Beverage] = list(items)

    @property
    def items(self) -> List[Beverage]:
        return list(self._items)

    def find(self, item_name: str) -> Beverage | None:
        for item in self._items:
            if item.name.lower() == item_name.lower():
                return item
        return None
