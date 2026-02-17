using System;
using System.Collections.Generic;
using CallinanBankLib;

Console.WriteLine("========================================");
Console.WriteLine("Callinan Bank Library Testing - START");
Console.WriteLine($"Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
Console.WriteLine("========================================");
Console.WriteLine();

// ----------------------------------------
// Inheritance & Polymorphism Test
// ----------------------------------------
Console.WriteLine("Inheritance & Polymorphism Test");

List<Account> accounts = new List<Account>
{
    new TravelAccount(3001, "Avery", 250m, 12.50m),
    new RewardsAccount(3002, "Jordan", 0.02m, 2, 1.50m),
    new StudentAccount(3003, "Taylor", 0.01m, 100m)
};

foreach (Account account in accounts)
{
    account.Deposit(500);
    account.Withdraw(75);
    account.ApplyMonthlyUpdate();
    Console.WriteLine(account);
}

Console.WriteLine();

// ----------------------------------------
// Operator Overloading Example
// ----------------------------------------
Console.WriteLine("Operator Overloading Example");

Account travel = accounts[0];
Account rewards = accounts[1];

decimal combinedBalance = travel + rewards;
Console.WriteLine($"Combined balance (Travel + Rewards): ${combinedBalance}");
Console.WriteLine("Use operator overloading sparingly—prefer clear methods for domain actions.");

Console.WriteLine();

// ----------------------------------------
// End
// ----------------------------------------
Console.WriteLine("========================================");
Console.WriteLine("Callinan Bank Library Testing - COMPLETE");
Console.WriteLine($"Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
Console.WriteLine("========================================");


// Smart Home Hub Test
SmartLightBulb bulb = new SmartLightBulb("bulb001", "Living Room Bulb");
SmartLightBulb bulb2 = new SmartLightBulb("bulb002", "Bedroom Bulb");
SmartLightBulb bulb3 = new SmartLightBulb("bulb003", "Kitchen Bulb");   

List<SmartDevice> devices = new List<SmartDevice>
{
    bulb,
    bulb2,
    bulb3
};

foreach (SmartDevice device in devices)
{
    device.TurnOn();
    device.ApplyMode("Reading");
    Console.WriteLine(device.GetStatus());
}
