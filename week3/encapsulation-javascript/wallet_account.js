class WalletAccount {
  #balance = 0;

  constructor(startingBalance = 0) {
    if (startingBalance < 0) {
      throw new Error("startingBalance must be >= 0");
    }
    this.#balance = startingBalance;
  }

  get balance() {
    return this.#balance;
  }

  deposit(amount) {
    if (amount <= 0) {
      throw new Error("amount must be > 0");
    }
    this.#balance += amount;
  }

  withdraw(amount) {
    if (amount <= 0) {
      throw new Error("amount must be > 0");
    }
    if (amount > this.#balance) {
      throw new Error("insufficient funds");
    }
    this.#balance -= amount;
  }
}

function makeWalletAccount(startingBalance = 0) {
  if (startingBalance < 0) {
    throw new Error("startingBalance must be >= 0");
  }

  let balance = startingBalance;

  return {
    getBalance() {
      return balance;
    },
    deposit(amount) {
      if (amount <= 0) {
        throw new Error("amount must be > 0");
      }
      balance += amount;
    },
    withdraw(amount) {
      if (amount <= 0) {
        throw new Error("amount must be > 0");
      }
      if (amount > balance) {
        throw new Error("insufficient funds");
      }
      balance -= amount;
    }
  };
}

function runTests() {
  const account = new WalletAccount(100);
  if (account.balance !== 100) {
    throw new Error("Expected starting balance to be 100");
  }

  account.deposit(50);
  if (account.balance !== 150) {
    throw new Error("Expected balance to be 150 after deposit");
  }

  account.withdraw(25);
  if (account.balance !== 125) {
    throw new Error("Expected balance to be 125 after withdraw");
  }

  const wallet = makeWalletAccount(200);
  wallet.deposit(100);
  if (wallet.getBalance() !== 300) {
    throw new Error("Expected balance to be 300 after deposit");
  }

  wallet.withdraw(75);
  if (wallet.getBalance() !== 225) {
    throw new Error("Expected balance to be 225 after withdraw");
  }
}

if (require.main === module) {
  runTests();
  console.log("All tests passed.");
}
