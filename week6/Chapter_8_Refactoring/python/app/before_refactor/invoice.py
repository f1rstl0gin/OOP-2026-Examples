from __future__ import annotations

"""
BEFORE REFACTOR (procedural).

Intentionally messy:
- Untyped dicts with magic keys
- Pricing rules embedded directly in one function
- Adding new line item types requires editing conditionals
"""

from datetime import date


def build_invoice_before() -> str:
    customer = {"id": "CUST-100", "name": "Acme Co.", "state": "PA"}

    lines = [
        {"type": "product", "sku": "WIDGET", "qty": 3, "unit_price": 19.99},
        {"type": "service", "name": "Install", "hours": 2.5, "rate": 65.00},
    ]

    subtotal = 0.0
    for line in lines:
        if line["type"] == "product":
            subtotal += line["qty"] * line["unit_price"]
        elif line["type"] == "service":
            subtotal += line["hours"] * line["rate"]

    discount = 0.05 * subtotal if subtotal > 100 else 0.0

    has_product = any(l["type"] == "product" for l in lines)
    shipping = 0.0
    if has_product:
        shipping = 0.0 if subtotal > 75 else 9.95

    taxable = subtotal - discount + shipping
    tax = 0.06 * taxable if customer["state"] == "PA" else 0.0
    total = taxable + tax

    return (
        f"Invoice Date: {date.today().isoformat()}\n"
        f"Customer: {customer['id']} - {customer['name']} ({customer['state']})\n"
        f"Subtotal: {subtotal:.2f}\n"
        f"Discount: -{discount:.2f}\n"
        f"Shipping: {shipping:.2f}\n"
        f"Tax: {tax:.2f}\n"
        f"TOTAL: {total:.2f}\n"
    )
