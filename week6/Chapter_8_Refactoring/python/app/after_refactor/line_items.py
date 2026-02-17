from __future__ import annotations

from dataclasses import dataclass
from abc import ABC, abstractmethod
from app.after_refactor.money import Money


class LineItem(ABC):
    """Polymorphic invoice line."""

    @abstractmethod
    def extended_price(self) -> Money:
        raise NotImplementedError

    @property
    @abstractmethod
    def is_shippable(self) -> bool:
        raise NotImplementedError


@dataclass(frozen=True, slots=True)
class ProductLine(LineItem):
    sku: str
    qty: int
    unit_price: Money

    def extended_price(self) -> Money:
        return self.unit_price * float(self.qty)

    @property
    def is_shippable(self) -> bool:
        return True


@dataclass(frozen=True, slots=True)
class ServiceLine(LineItem):
    name: str
    hours: float
    rate: Money

    def extended_price(self) -> Money:
        return self.rate * float(self.hours)

    @property
    def is_shippable(self) -> bool:
        return False
