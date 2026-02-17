using OopOrganization.Refactoring;

Console.WriteLine("=== BEFORE (procedural) ===");
Console.WriteLine(InvoiceBefore.Build());

Console.WriteLine();
Console.WriteLine("=== AFTER (refactored to OOP) ===");
Console.WriteLine(InvoiceAfter.Build());
