# Chapter 8 (JavaScript) — Refactoring to “Full OOP” (BEFORE + AFTER)

This folder contains **two versions of the same invoice problem**:

- **BEFORE** (`src/beforeRefactor/invoice.js`): procedural code + branching
- **AFTER** (`src/afterRefactor/*`): OO code using **polymorphism + policies + a calculator service**

## Quick file map
- BEFORE
  - `src/beforeRefactor/invoice.js` → `buildInvoiceBefore()`
- AFTER
  - `src/afterRefactor/money.js` → `Money`
  - `src/afterRefactor/lineItems.js` → `LineItem` + `ProductLine`/`ServiceLine`
  - `src/afterRefactor/policies.js` → discount/shipping/tax policy objects
  - `src/afterRefactor/invoice.js` → `InvoiceCalculator` + `buildInvoiceAfter()`

## Run
From this **javascript** folder:

```bash
npm install
npm run demo
```

`src/main.js` prints BOTH sections:

1) `=== BEFORE (procedural) ===`
2) `=== AFTER (refactored to OOP) ===`

## What students should notice
- BEFORE: adding a new line type forces edits to the branching logic.
- AFTER: adding a new line type is a new class; calculator logic stays unchanged.
