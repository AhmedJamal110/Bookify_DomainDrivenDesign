namespace Bookify.Infrastructre.Repositories;
internal sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(ApplicationDbContext _context) 
        : base(_context)
    {
    }

    private static readonly BookingStatus[] ActiveBookingStatuses =
    {
        BookingStatus.Reserved,
        BookingStatus.Confirmed,
        BookingStatus.Completed
    };


    public async Task<IReadOnlyList<Apartment>> SearchAvaiableApartments(
        DateOnly startDate, 
        DateOnly endDate,
        CancellationToken cancellationToken = default)
    {
        return await _context.Apartments
            .Where(a => !a.Bookings
                   .Any(b =>
                          ActiveBookingStatuses.Contains(b.Status) &&
                          b.Duration.Start <= endDate && b.Duration.End >= startDate))
            .ToListAsync(cancellationToken);
    }

    public async Task CreateApartmentAync(Apartment apartment, CancellationToken cancellationToken)
    {
        await _context.Set<Apartment>().AddAsync(apartment, cancellationToken);
    }
}
