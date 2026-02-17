# Chapter 8 (C#) — Refactoring to “Full OOP” (BEFORE + AFTER)

This folder contains **two versions of the same invoice problem**:

- **BEFORE** (`Refactoring/InvoiceBefore.cs`): procedural-ish code using dictionaries + branching
- **AFTER** (`Refactoring/InvoiceAfter.cs` plus supporting types): OO code using **interfaces + policies + a calculator service**

## Quick file map
- BEFORE
  - `src/OopOrganization.Chapter8/Refactoring/InvoiceBefore.cs` → `InvoiceBefore.Build()`
- AFTER
  - `src/OopOrganization.Chapter8/Refactoring/Money.cs` → `Money` value object (`record struct`)
  - `src/OopOrganization.Chapter8/Refactoring/LineItems.cs` → `ILineItem` + concrete line types
  - `src/OopOrganization.Chapter8/Refactoring/Policies.cs` → discount/shipping/tax policies
  - `src/OopOrganization.Chapter8/Refactoring/InvoiceAfter.cs` → `InvoiceCalculator` + `InvoiceAfter.Build()`
- Runner
  - `src/OopOrganization.Chapter8/Program.cs` prints BEFORE then AFTER

## Build & run (NET 8)
From this **csharp** folder:

```bash
dotnet build
dotnet run --project src/OopOrganization.Chapter8/OopOrganization.Chapter8.csproj
```

## What students should notice
- BEFORE: rules are “entangled” in one method and depend on the dictionary shape.
- AFTER: behavior is split across responsibilities; extending line types uses the `ILineItem` contract.
