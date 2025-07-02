
using Bookify.Infrastructre.Database;

namespace Bookify.Infrastructre.Repositories;
internal sealed class ApartmentRepository(
    ApplicationDbContext _context) : IApartmentRepository
{

    private static readonly int[] ActiveBookingStatuses =
    {
        (int)BookingStatus.Reserved,
        (int)BookingStatus.Confirmed,
        (int)BookingStatus.Completed
    };

    public async Task<Apartment?> GetByIDAsync(
        Guid id, 
        CancellationToken cancellationToken = default)
    {
        return await _context
            .Apartments
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Apartment>> SearchAvaiableApartments(
        DateOnly startDate, 
        DateOnly endDate,
        CancellationToken cancellationToken = default)
    {
        var apartments = await _context.Apartments
            .Where(a => a.Bookings
                .Any(b =>
                       ActiveBookingStatuses.Contains((int)b.Status) &&
                       b.Duration.Start <= endDate && b.Duration.End >= startDate))
             .ToListAsync(cancellationToken);

        /// Select 


        return apartments;



    }
}
