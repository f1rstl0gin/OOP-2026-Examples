from __future__ import annotations

from dataclasses import dataclass
from typing import Iterable
from app.after_refactor.money import Money
from app.after_refactor.line_items import LineItem


@dataclass(frozen=True, slots=True)
class Customer:
    id: str
    name: str
    state: str


class DiscountPolicy:
    def discount(self, subtotal: Money) -> Money:
        # 5% over $100
        return subtotal * 0.05 if subtotal.amount > 100 else Money(0.0, subtotal.currency)


class ShippingPolicy:
    def shipping(self, items: Iterable[LineItem], subtotal: Money) -> Money:
        has_shippable = any(i.is_shippable for i in items)
        if not has_shippable:
            return Money(0.0, subtotal.currency)
        return Money(0.0, subtotal.currency) if subtotal.amount > 75 else Money(9.95, subtotal.currency)


class TaxPolicy:
    def tax(self, customer: Customer, taxable_amount: Money) -> Money:
        return taxable_amount * 0.06 if customer.state == "PA" else Money(0.0, taxable_amount.currency)
