from __future__ import annotations

from dataclasses import dataclass
from datetime import date
from typing import Iterable
from app.after_refactor.money import Money
from app.after_refactor.line_items import LineItem, ProductLine, ServiceLine
from app.after_refactor.pricing import Customer, DiscountPolicy, ShippingPolicy, TaxPolicy


@dataclass(frozen=True, slots=True)
class InvoiceTotals:
    subtotal: Money
    discount: Money
    shipping: Money
    tax: Money
    total: Money


class InvoiceCalculator:
    def __init__(
        self,
        discount_policy: DiscountPolicy | None = None,
        shipping_policy: ShippingPolicy | None = None,
        tax_policy: TaxPolicy | None = None,
    ) -> None:
        self._discount = discount_policy or DiscountPolicy()
        self._shipping = shipping_policy or ShippingPolicy()
        self._tax = tax_policy or TaxPolicy()

    def totals(self, customer: Customer, items: Iterable[LineItem]) -> InvoiceTotals:
        items_list = list(items)
        subtotal = Money(0.0)
        for item in items_list:
            subtotal = subtotal + item.extended_price()

        discount = self._discount.discount(subtotal)
        shipping = self._shipping.shipping(items_list, subtotal)

        taxable = subtotal - discount + shipping
        tax = self._tax.tax(customer, taxable)

        total = taxable + tax
        return InvoiceTotals(subtotal=subtotal, discount=discount, shipping=shipping, tax=tax, total=total)


def build_invoice_after() -> str:
    customer = Customer(id="CUST-100", name="Acme Co.", state="PA")
    items: list[LineItem] = [
        ProductLine(sku="WIDGET", qty=3, unit_price=Money(19.99)),
        ServiceLine(name="Install", hours=2.5, rate=Money(65.00)),
    ]

    calc = InvoiceCalculator()
    t = calc.totals(customer, items)

    return (
        f"Invoice Date: {date.today().isoformat()}\n"
        f"Customer: {customer.id} - {customer.name} ({customer.state})\n"
        f"Subtotal: {t.subtotal.fmt()}\n"
        f"Discount: -{t.discount.fmt()}\n"
        f"Shipping: {t.shipping.fmt()}\n"
        f"Tax: {t.tax.fmt()}\n"
        f"TOTAL: {t.total.fmt()}\n"
    )
