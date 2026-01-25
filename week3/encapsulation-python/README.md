# Week 3 – Encapsulation (Python)

This VS Code project demonstrates encapsulation and controlled access for a bank account.

## Key Ideas

- Internal state is stored in `_balance`.
- Public access is read-only via the `balance` property.
- All state changes go through `deposit` and `withdraw`, which enforce invariants.

## Run the example

```bash
python3 bank_account.py
```

The script runs a few quick assertions to verify the invariants.
