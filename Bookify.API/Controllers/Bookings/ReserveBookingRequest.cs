namespace Bookify.API.Controllers.Bookings;

public sealed record ReserveBookingRequest
{
    public required Guid ApartmentId { get; set; }
    public required Guid UserId { get; set; }
    public required DateOnly StartDate { get; set; }
    public required DateOnly EndDate { get; set; }
};
