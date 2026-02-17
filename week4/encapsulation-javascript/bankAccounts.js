class BankAccount {
  constructor(owner, accountType, startingBalance = 0) {
    if (startingBalance < 0) {
      throw new Error("startingBalance must be >= 0");
    }
    this.owner = owner;
    this.accountType = accountType;
    this._balance = startingBalance;
    this._history = ["Account opened"];
  }

  get balance() {
    return this._balance;
  }

  deposit(amount) {
    if (amount <= 0) {
      throw new Error("amount must be > 0");
    }
    this._balance += amount;
    this._history.push(`Deposited $${amount}`);
  }

  withdraw(amount) {
    if (amount <= 0) {
      throw new Error("amount must be > 0");
    }
    if (amount > this._balance) {
      throw new Error("insufficient funds");
    }
    this._balance -= amount;
    this._history.push(`Withdrew $${amount}`);
  }

  applyMonthlyUpdate() {}

  history() {
    return [...this._history];
  }

  toString() {
    return `Account(${this.accountType}) - ${this.owner}: $${this._balance}`;
  }

  static combineBalances(left, right) {
    return left._balance + right._balance;
  }
}

class TravelAccount extends BankAccount {
  constructor(owner, overdraftLimit, monthlyFee, startingBalance = 0) {
    super(owner, "Travel", startingBalance);
    this.overdraftLimit = overdraftLimit;
    this.monthlyFee = monthlyFee;
  }

  withdraw(amount) {
    if (amount <= 0) {
      throw new Error("amount must be > 0");
    }
    if (amount > this._balance + this.overdraftLimit) {
      throw new Error("overdraft limit exceeded");
    }
    this._balance -= amount;
    this._history.push(`Withdrew $${amount}`);
  }

  applyMonthlyUpdate() {
    if (this.monthlyFee <= 0) {
      return;
    }
    if (this.monthlyFee > this._balance + this.overdraftLimit) {
      return;
    }
    this._balance -= this.monthlyFee;
    this._history.push(`Monthly fee applied: $${this.monthlyFee}`);
  }
}

class RewardsAccount extends BankAccount {
  constructor(owner, bonusRate, freeWithdrawals, withdrawalFee, startingBalance = 0) {
    super(owner, "Rewards", startingBalance);
    this.bonusRate = bonusRate;
    this.freeWithdrawals = freeWithdrawals;
    this.withdrawalFee = withdrawalFee;
    this._withdrawalsThisMonth = 0;
  }

  deposit(amount) {
    super.deposit(amount);
    if (this.bonusRate > 0) {
      const bonus = amount * this.bonusRate;
      if (bonus > 0) {
        this._balance += bonus;
        this._history.push(`Rewards bonus applied: $${bonus}`);
      }
    }
  }

  withdraw(amount) {
    super.withdraw(amount);
    this._withdrawalsThisMonth += 1;
    if (this._withdrawalsThisMonth > this.freeWithdrawals && this.withdrawalFee > 0) {
      if (this.withdrawalFee > this._balance) {
        throw new Error("insufficient funds for fee");
      }
      this._balance -= this.withdrawalFee;
      this._history.push(`Withdrawal fee applied: $${this.withdrawalFee}`);
    }
  }

  applyMonthlyUpdate() {
    this._withdrawalsThisMonth = 0;
  }
}

class StudentAccount extends BankAccount {
  constructor(owner, monthlyInterestRate, dailyWithdrawalLimit, startingBalance = 0) {
    super(owner, "Student", startingBalance);
    this.monthlyInterestRate = monthlyInterestRate;
    this.dailyWithdrawalLimit = dailyWithdrawalLimit;
  }

  withdraw(amount) {
    if (amount > this.dailyWithdrawalLimit) {
      throw new Error("daily limit exceeded");
    }
    super.withdraw(amount);
  }

  applyMonthlyUpdate() {
    if (this.monthlyInterestRate <= 0) {
      return;
    }
    const interest = this._balance * this.monthlyInterestRate;
    if (interest > 0) {
      this._balance += interest;
      this._history.push(`Monthly interest applied: $${interest}`);
    }
  }
}

function runDemo() {
  const accounts = [
    new TravelAccount("Avery", 250, 12.5, 500),
    new RewardsAccount("Jordan", 0.02, 2, 1.5, 500),
    new StudentAccount("Taylor", 0.01, 100, 500)
  ];

  for (const account of accounts) {
    account.deposit(75);
    account.withdraw(50);
    account.applyMonthlyUpdate();
    console.log(account.toString());
  }

  const combined = BankAccount.combineBalances(accounts[0], accounts[1]);
  console.log(`Combined balance (Travel + Rewards): $${combined}`);
  console.log("Operator overloading isn't in JS; use explicit methods for clarity.");
}

if (require.main === module) {
  runDemo();
}
