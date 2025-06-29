namespace Bookify.Domain.Apartments;
public sealed record Currency
{
    public static readonly Currency USD = new("USD");
    public static readonly Currency EUR = new("EUR");
    internal static readonly Currency None = new(string.Empty);


    private Currency(string code)
    {
        Code = code;
    }


    public string Code { get; init; }

    public static Currency FromCode(string code)
    {
       return All.FirstOrDefault(c => c.Code == code) ??
            throw new ApplicationException($"Currency with code '{code}' does not exist.");
    }


    public static readonly IReadOnlyCollection<Currency> All = new[]
    {
        USD,
        EUR
    };

}
