namespace OopOrganization.Refactoring;

// BEFORE REFACTOR (procedural), intentionally messy.
public static class InvoiceBefore
{
    public static string Build()
    {
        var customer = new Dictionary<string, object>
        {
            ["id"] = "CUST-100",
            ["name"] = "Acme Co.",
            ["state"] = "PA"
        };

        var lines = new List<Dictionary<string, object>>
        {
            new()
            {
                ["type"] = "product",
                ["sku"] = "WIDGET",
                ["qty"] = 3,
                ["unitPrice"] = 19.99
            },
            new()
            {
                ["type"] = "service",
                ["name"] = "Install",
                ["hours"] = 2.5,
                ["rate"] = 65.00
            }
        };

        double subtotal = 0;
        foreach (var line in lines)
        {
            var type = (string)line["type"];
            if (type == "product")
                subtotal += (int)line["qty"] * (double)line["unitPrice"];
            else if (type == "service")
                subtotal += (double)line["hours"] * (double)line["rate"];
        }

        var discount = subtotal > 100 ? 0.05 * subtotal : 0.0;

        var hasProduct = lines.Any(l => (string)l["type"] == "product");
        var shipping = hasProduct ? (subtotal > 75 ? 0.0 : 9.95) : 0.0;

        var taxable = subtotal - discount + shipping;
        var tax = (string)customer["state"] == "PA" ? 0.06 * taxable : 0.0;

        var total = taxable + tax;

        return string.Join(Environment.NewLine, new[]
        {
            $"Customer: {customer["id"]} - {customer["name"]} ({customer["state"]})",
            $"Subtotal: {subtotal:F2}",
            $"Discount: -{discount:F2}",
            $"Shipping: {shipping:F2}",
            $"Tax: {tax:F2}",
            $"TOTAL: {total:F2}",
        });
    }
}
