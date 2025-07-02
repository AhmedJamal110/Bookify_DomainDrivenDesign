namespace Bookify.Application.Apartments.SearchApartment;
public sealed record SearchAprtmentQuery(
    DateOnly StartDate,
    DateOnly EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>;
