namespace OopOrganization.Refactoring;

public interface ILineItem
{
    Money ExtendedPrice();
    bool IsShippable { get; }
}

public sealed record ProductLine(string Sku, int Qty, Money UnitPrice) : ILineItem
{
    public Money ExtendedPrice() => UnitPrice.Mul(Qty);
    public bool IsShippable => true;
}

public sealed record ServiceLine(string Name, decimal Hours, Money Rate) : ILineItem
{
    public Money ExtendedPrice() => Rate.Mul(Hours);
    public bool IsShippable => false;
}
