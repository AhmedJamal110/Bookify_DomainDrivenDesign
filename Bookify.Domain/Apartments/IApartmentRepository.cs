namespace Bookify.Domain.Apartments;
public interface IApartmentRepository
{
    Task<Apartment?> GetByIDAsync(Guid id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Apartment>> SearchAvaiableApartments(
        DateOnly startDate,
        DateOnly endDate,
        CancellationToken cancellationToken = default);
}
