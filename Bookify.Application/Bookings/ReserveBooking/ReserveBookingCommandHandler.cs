
using Bookify.Application.Exceptions;

namespace Bookify.Application.Bookings.ReserveBooking;
internal sealed class ReserveBookingCommandHandler(
    IUserRepository _userRepository,
    IApartmentRepository _apartmentRepository,
    IBookingRepository _bookingRepository,
    PricingService _pricingService,
    IUnitOfWork _unitOfWork,
    IDateTimeProvider _dateTimeProvider) : ICommandHandler<ReserveBookingCommand, Guid>
{
    public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetByIDAsync(request.UserId, cancellationToken);
        
        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        Apartment? apartment = await _apartmentRepository.GetByIDAsync(request.ApartmentId , cancellationToken);

        if (apartment is null)
        {
            return Result.Failure<Guid>(ApartmentErrors.NotFound);
        }


        var dateRange = DateRange.Create(request.StartDate, request.EndDate);

        bool isOverlap = await _bookingRepository.IsOverlappingAsync(apartment, dateRange, cancellationToken);
     
        
        if(isOverlap)
        {
            return Result.Failure<Guid>(BookingErrors.Overlap);
        }


        try
        {
            var booking = Booking.Reserve(
                apartment,
                user.Id,
                dateRange,
                _dateTimeProvider.UtcNow,
                _pricingService);


            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(booking.Id);
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(BookingErrors.Overlap);
        }

       


    }


}
