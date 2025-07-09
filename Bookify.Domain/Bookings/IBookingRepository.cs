using Bookify.Domain.Apartments;

namespace Bookify.Domain.Bookings;
public interface IBookingRepository
{
    Task<Booking?> GetByIDAsync(
        Guid id, 
        CancellationToken cancellationToken = default);

    Task<bool> IsOverlappingAsync(
        Apartment apartment,
        DateRange duration,
        CancellationToken cancellationToken = default);

    Task AddAsync(Booking booking , CancellationToken cancellationToken = default);
}
