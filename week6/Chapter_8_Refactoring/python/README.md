# Chapter 8 (Python) — Refactoring to “Full OOP” (BEFORE + AFTER)

This folder contains **two versions of the same invoice problem**:

- **BEFORE** (`app/before_refactor/invoice.py`): procedural code + branching + dicts with magic keys
- **AFTER** (`app/after_refactor/*`): object-oriented code using **polymorphism + policies + a calculator service**

## Quick file map
- BEFORE
  - `app/before_refactor/invoice.py` → `build_invoice_before()`
- AFTER
  - `app/after_refactor/money.py` → `Money` value object
  - `app/after_refactor/line_items.py` → `LineItem` + `ProductLine`/`ServiceLine`
  - `app/after_refactor/pricing.py` → `DiscountPolicy` / `ShippingPolicy` / `TaxPolicy`
  - `app/after_refactor/invoice.py` → `InvoiceCalculator` + `build_invoice_after()`

## Run (recommended)
From this **python** folder:

```bash
python -m venv .venv
.venv\Scripts\activate   # Windows
# source .venv/bin/activate  # macOS/Linux

python -m app.main
```

Alternative (also works):

```bash
python app/main.py
```

## What students should notice
- BEFORE: changing behavior means editing conditionals + shared data shape.
- AFTER: add a new line item by creating a new class; pricing variations live in swappable policy classes.
