using Bookify.Application.Abstractions.Email;
using Bookify.Domain.Bookings.Events;

namespace Bookify.Application.Bookings.ReserveBooking;
internal sealed class BookingReservedDomainEventHandler(
    IBookingRepository _bookingRepository,
    IUserRepository _userRepository,
     IEmailService _emailService) : INotificationHandler<BookingCancelledDomainEvents>
{
    public async Task Handle(
        BookingCancelledDomainEvents notification,
        CancellationToken cancellationToken)
    {
        Booking? booking = await _bookingRepository.GetByIDAsync(notification.Id, cancellationToken);

        if (booking is null)
        {
            return;
        }


        User? user = await _userRepository.GetByIDAsync(booking.UserId, cancellationToken);

        if (user is null)
        {
            return;
        }


        await _emailService.SendAsync(
            user.Email,
            "Booking Reservied",
            "You have IO minutes to confirm this bookin");

    }
}
