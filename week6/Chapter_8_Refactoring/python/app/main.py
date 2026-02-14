"""
Chapter 8 (Python): runnable entry point (BEFORE + AFTER).

Recommended run from this folder:
  python -m app.main

Direct run also supported:
  python app/main.py
"""
from __future__ import annotations

if __name__ == "__main__" and __package__ is None:
    import os
    import sys
    sys.path.insert(0, os.path.dirname(os.path.dirname(__file__)))

from app.before_refactor.invoice import build_invoice_before
from app.after_refactor.invoice import build_invoice_after


def main() -> None:
    print("=== BEFORE (procedural) ===")
    print(build_invoice_before())

    print("\n=== AFTER (refactored to OOP) ===")
    print(build_invoice_after())


if __name__ == "__main__":
    main()
