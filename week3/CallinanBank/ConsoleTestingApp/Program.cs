using System;
using CallinanBankLib;

Console.WriteLine("========================================");
Console.WriteLine("Callinan Bank Library Testing - START");
Console.WriteLine($"Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
Console.WriteLine("========================================");
Console.WriteLine();


// ----------------------------------------
// Base Account Test
// ----------------------------------------
Console.WriteLine("Base Account Test");

Account acct = new Account(12345, "Alice Smith", Account.AccountType.Savings);

Console.WriteLine($"Initial Balance: {acct.Balance}");

acct.Deposit(500);
Console.WriteLine("Deposited $500");
Console.WriteLine($"Balance: {acct.Balance}");

bool withdrew = acct.Withdraw(125);
Console.WriteLine($"Withdraw $125: {(withdrew ? "SUCCESS" : "FAILED")}");
Console.WriteLine($"Balance: {acct.Balance}");

Console.WriteLine();


// ----------------------------------------
// Inheritance & Polymorphism Test
// ----------------------------------------
Console.WriteLine("Inheritance Test (Savings vs Checking)");

Account savings = new SavingsAccount(1001, "Alice", 0.02m);
Account checking = new CheckingAccount(2001, "Bob", 400);

savings.Deposit(500);
checking.Deposit(200);

Console.WriteLine($"Savings Balance after deposit: {savings.Balance}");
Console.WriteLine($"Checking Balance after deposit: {checking.Balance}");

bool savingsWithdraw = savings.Withdraw(100);
bool checkingWithdraw = checking.Withdraw(400); // overdraft allowed

Console.WriteLine($"Savings Withdraw $100: {(savingsWithdraw ? "SUCCESS" : "FAILED")}");
Console.WriteLine($"Savings Balance: {savings.Balance}");

Console.WriteLine($"Checking Withdraw $400 (Overdraft): {(checkingWithdraw ? "SUCCESS" : "FAILED")}");
Console.WriteLine($"Checking Balance: {checking.Balance}");

Console.WriteLine();


// ----------------------------------------
// End
// ----------------------------------------
Console.WriteLine("========================================");
Console.WriteLine("Callinan Bank Library Testing - COMPLETE");
Console.WriteLine($"Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
Console.WriteLine("========================================");
