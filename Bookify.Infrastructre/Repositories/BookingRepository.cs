namespace Bookify.Infrastructre.Repositories;
internal sealed class BookingRepository : Repository<Booking> , IBookingRepository
{
    public BookingRepository(ApplicationDbContext context) : base(context)
    {
    }

    private static readonly BookingStatus[] ActiveBookingStatuses =
    {
        BookingStatus.Reserved,
        BookingStatus.Confirmed,
        BookingStatus.Completed
    };



    public async Task<bool> IsOverlappingAsync(
        Apartment apartment, 
        DateRange duration,
        CancellationToken cancellationToken = default)
    {

        return await _context.Bookings
            .AnyAsync(
              b =>
                      b.ApaermentId == apartment.Id &&
                      b.Duration.Start <= duration.End &&
                      b.Duration.End >= duration.Start &&
                      ActiveBookingStatuses.Contains(b.Status),
              cancellationToken: cancellationToken);
    }
}
