# Chapter 7 (Python) — Organization of Object-Oriented Code

This mini-project demonstrates how to organize object-oriented Python code using:

- Packages and subpackages (`app/domain/...`)
- Clear import paths
- A “domain + services” layout that scales

## Folder map
- `app/domain/geometry/contracts.py` — abstract base contract + value objects
- `app/domain/geometry/shapes.py` — concrete shape classes
- `app/domain/geometry/reporting.py` — a service that depends on the contract

## Run
From this folder:

```bash
python -m venv .venv
.venv\Scripts\activate   # Windows
# source .venv/bin/activate  # macOS/Linux

python -m app.main  (recommended)
```

## What to look for in lecture
- `ShapeReporter` depends on the **Shape contract**, not concrete types.
- Shapes are grouped into a domain package. Call sites import from the domain.


Alternative (also works):

```bash
python app/main.py
```
