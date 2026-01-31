class BankAccount:
    def __init__(self, owner, account_type, starting_balance=0):
        if starting_balance < 0:
            raise ValueError("starting_balance must be >= 0")
        self.owner = owner
        self.account_type = account_type
        self._balance = starting_balance
        self._history = ["Account opened"]

    @property
    def balance(self):
        return self._balance

    def deposit(self, amount):
        if amount <= 0:
            raise ValueError("amount must be > 0")
        self._balance += amount
        self._history.append(f"Deposited ${amount}")

    def withdraw(self, amount):
        if amount <= 0:
            raise ValueError("amount must be > 0")
        if amount > self._balance:
            raise ValueError("insufficient funds")
        self._balance -= amount
        self._history.append(f"Withdrew ${amount}")

    def apply_monthly_update(self):
        pass

    def history(self):
        return list(self._history)

    def __repr__(self):
        return f"BankAccount(owner={self.owner!r}, type={self.account_type}, balance={self._balance})"

    def __add__(self, other):
        if not isinstance(other, BankAccount):
            return NotImplemented
        return self._balance + other._balance


class TravelAccount(BankAccount):
    def __init__(self, owner, overdraft_limit, monthly_fee, starting_balance=0):
        super().__init__(owner, "Travel", starting_balance)
        self.overdraft_limit = overdraft_limit
        self.monthly_fee = monthly_fee

    def withdraw(self, amount):
        if amount <= 0:
            raise ValueError("amount must be > 0")
        if amount > self._balance + self.overdraft_limit:
            raise ValueError("overdraft limit exceeded")
        self._balance -= amount
        self._history.append(f"Withdrew ${amount}")

    def apply_monthly_update(self):
        if self.monthly_fee <= 0:
            return
        if self.monthly_fee > self._balance + self.overdraft_limit:
            return
        self._balance -= self.monthly_fee
        self._history.append(f"Monthly fee applied: ${self.monthly_fee}")


class RewardsAccount(BankAccount):
    def __init__(self, owner, bonus_rate, free_withdrawals, withdrawal_fee, starting_balance=0):
        super().__init__(owner, "Rewards", starting_balance)
        self.bonus_rate = bonus_rate
        self.free_withdrawals = free_withdrawals
        self.withdrawal_fee = withdrawal_fee
        self._withdrawals_this_month = 0

    def deposit(self, amount):
        super().deposit(amount)
        if self.bonus_rate > 0:
            bonus = amount * self.bonus_rate
            if bonus > 0:
                self._balance += bonus
                self._history.append(f"Rewards bonus applied: ${bonus}")

    def withdraw(self, amount):
        super().withdraw(amount)
        self._withdrawals_this_month += 1
        if self._withdrawals_this_month > self.free_withdrawals and self.withdrawal_fee > 0:
            if self.withdrawal_fee > self._balance:
                raise ValueError("insufficient funds for fee")
            self._balance -= self.withdrawal_fee
            self._history.append(f"Withdrawal fee applied: ${self.withdrawal_fee}")

    def apply_monthly_update(self):
        self._withdrawals_this_month = 0


class StudentAccount(BankAccount):
    def __init__(self, owner, monthly_interest_rate, daily_withdrawal_limit, starting_balance=0):
        super().__init__(owner, "Student", starting_balance)
        self.monthly_interest_rate = monthly_interest_rate
        self.daily_withdrawal_limit = daily_withdrawal_limit

    def withdraw(self, amount):
        if amount > self.daily_withdrawal_limit:
            raise ValueError("daily limit exceeded")
        super().withdraw(amount)

    def apply_monthly_update(self):
        if self.monthly_interest_rate <= 0:
            return
        interest = self._balance * self.monthly_interest_rate
        if interest > 0:
            self._balance += interest
            self._history.append(f"Monthly interest applied: ${interest}")


def run_demo():
    accounts = [
        TravelAccount("Avery", overdraft_limit=250, monthly_fee=12.5, starting_balance=500),
        RewardsAccount("Jordan", bonus_rate=0.02, free_withdrawals=2, withdrawal_fee=1.5, starting_balance=500),
        StudentAccount("Taylor", monthly_interest_rate=0.01, daily_withdrawal_limit=100, starting_balance=500),
    ]

    for account in accounts:
        account.deposit(75)
        account.withdraw(50)
        account.apply_monthly_update()
        print(account)

    combined = accounts[0] + accounts[1]
    print(f"Combined balance (Travel + Rewards): ${combined}")
    print("Operator overloading can be helpful, but clear methods are usually better in banking.")


if __name__ == "__main__":
    run_demo()
