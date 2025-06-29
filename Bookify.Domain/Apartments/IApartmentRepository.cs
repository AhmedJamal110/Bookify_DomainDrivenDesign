namespace Bookify.Domain.Apartments;
public interface IApartmentRepository
{
    Task<Apartment?> GetByIDAsync(Guid id, CancellationToken cancellationToken = default);
}
