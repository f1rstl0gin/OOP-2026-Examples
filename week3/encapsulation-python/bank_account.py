class BankAccount:
    def __init__(self, owner, starting_balance=0):
        if starting_balance < 0:
            raise ValueError("starting_balance must be >= 0")
        self.owner = owner
        self._balance = starting_balance
        
    @property
    def balance(self):
        return self._balance

    def deposit(self, amount):
        if amount <= 0:
            raise ValueError("amount must be > 0")
        self._balance += amount

    def withdraw(self, amount):
        if amount <= 0:
            raise ValueError("amount must be > 0")
        if amount > self._balance:
            raise ValueError("insufficient funds")
        self._balance -= amount

    def __repr__(self):
        return f"BankAccount(owner={self.owner!r}, balance={self._balance})"


def run_tests():
    account = BankAccount("Jordan", 100)
    assert account.balance == 100

    account.deposit(50)
    assert account.balance == 150

    account.withdraw(25)
    assert account.balance == 125

    try:
        account.deposit(0)
    except ValueError as exc:
        assert str(exc) == "amount must be > 0"
    else:
        raise AssertionError("deposit should reject non-positive values")

    try:
        account.withdraw(500)
    except ValueError as exc:
        assert str(exc) == "insufficient funds"
    else:
        raise AssertionError("withdraw should reject overdrafts")


if __name__ == "__main__":
    run_tests()
    print("All tests passed.")
