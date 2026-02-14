# Chapter 8 — Refactoring Structure (BEFORE + AFTER)

## Key refactoring move
- **BEFORE**: branching + magic-key dictionaries in one function.
- **AFTER**: contracts + polymorphism + policy objects.

## Python
```mermaid
flowchart TD
  subgraph BEFORE
    B1[before_refactor/invoice.py]
  end

  subgraph AFTER
    A0[after_refactor/]
    A0 --> A1[money.py]
    A0 --> A2[line_items.py]
    A0 --> A3[pricing.py]
    A0 --> A4[invoice.py]
    A4 --> A1
    A4 --> A2
    A4 --> A3
  end
```
Teaching angle:
- Replace `if/elif` with **polymorphic line items**.
- Move rule variations into **policies**.

## C#
```mermaid
flowchart TD
  subgraph BEFORE
    C1[Refactoring/InvoiceBefore.cs]
  end

  subgraph AFTER
    A0[Refactoring/]
    A0 --> M[Money.cs]
    A0 --> L[LineItems.cs]
    A0 --> P[Policies.cs]
    A0 --> I[InvoiceAfter.cs]
  end
```
Teaching angle:
- `ILineItem` enables open/closed extension.
- Policies are swappable for tests or different regions.

## JavaScript
```mermaid
flowchart TD
  subgraph BEFORE
    J1[src/beforeRefactor/invoice.js]
  end

  subgraph AFTER
    A0[src/afterRefactor/]
    A0 --> M[money.js]
    A0 --> L[lineItems.js]
    A0 --> P[policies.js]
    A0 --> I[invoice.js]
  end
```
