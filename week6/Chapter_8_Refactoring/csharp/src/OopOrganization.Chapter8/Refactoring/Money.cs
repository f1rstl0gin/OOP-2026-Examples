namespace OopOrganization.Refactoring;

public readonly record struct Money(decimal Amount, string Currency = "USD")
{
    public Money Add(Money other) => Check(other) ? new Money(Amount + other.Amount, Currency) : throw new InvalidOperationException();
    public Money Sub(Money other) => Check(other) ? new Money(Amount - other.Amount, Currency) : throw new InvalidOperationException();
    public Money Mul(decimal factor) => new Money(Amount * factor, Currency);

    private bool Check(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException($"Currency mismatch: {Currency} vs {other.Currency}");
        return true;
    }

    public string Fmt() => $"{Amount:F2} {Currency}";
}
