namespace OopOrganization.Refactoring;

public sealed class InvoiceCalculator
{
    private readonly DiscountPolicy _discount;
    private readonly ShippingPolicy _shipping;
    private readonly TaxPolicy _tax;

    public InvoiceCalculator(DiscountPolicy? discount = null, ShippingPolicy? shipping = null, TaxPolicy? tax = null)
    {
        _discount = discount ?? new DiscountPolicy();
        _shipping = shipping ?? new ShippingPolicy();
        _tax = tax ?? new TaxPolicy();
    }

    public (Money Subtotal, Money Discount, Money Shipping, Money Tax, Money Total) Totals(Customer customer, IEnumerable<ILineItem> items)
    {
        var list = items.ToList();

        var subtotal = new Money(0m);
        foreach (var item in list)
            subtotal = subtotal.Add(item.ExtendedPrice());

        var discount = _discount.Discount(subtotal);
        var shipping = _shipping.Shipping(list, subtotal);

        var taxable = subtotal.Sub(discount).Add(shipping);
        var tax = _tax.Tax(customer, taxable);

        var total = taxable.Add(tax);
        return (subtotal, discount, shipping, tax, total);
    }
}

public static class InvoiceAfter
{
    public static string Build()
    {
        var customer = new Customer("CUST-100", "Acme Co.", "PA");
        ILineItem[] items =
        [
            new ProductLine("WIDGET", 3, new Money(19.99m)),
            new ServiceLine("Install", 2.5m, new Money(65.00m)),
        ];

        var calc = new InvoiceCalculator();
        var t = calc.Totals(customer, items);

        return string.Join(Environment.NewLine, new[]
        {
            $"Customer: {customer.Id} - {customer.Name} ({customer.State})",
            $"Subtotal: {t.Subtotal.Fmt()}",
            $"Discount: -{t.Discount.Fmt()}",
            $"Shipping: {t.Shipping.Fmt()}",
            $"Tax: {t.Tax.Fmt()}",
            $"TOTAL: {t.Total.Fmt()}",
        });
    }
}
