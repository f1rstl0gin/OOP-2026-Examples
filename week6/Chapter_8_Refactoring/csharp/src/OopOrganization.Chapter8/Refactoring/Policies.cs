namespace OopOrganization.Refactoring;

public sealed record Customer(string Id, string Name, string State);

public sealed class DiscountPolicy
{
    public Money Discount(Money subtotal)
        => subtotal.Amount > 100m ? subtotal.Mul(0.05m) : new Money(0m, subtotal.Currency);
}

public sealed class ShippingPolicy
{
    public Money Shipping(IEnumerable<ILineItem> items, Money subtotal)
    {
        var hasShippable = items.Any(i => i.IsShippable);
        if (!hasShippable) return new Money(0m, subtotal.Currency);
        return subtotal.Amount > 75m ? new Money(0m, subtotal.Currency) : new Money(9.95m, subtotal.Currency);
    }
}

public sealed class TaxPolicy
{
    public Money Tax(Customer customer, Money taxable)
        => customer.State == "PA" ? taxable.Mul(0.06m) : new Money(0m, taxable.Currency);
}
