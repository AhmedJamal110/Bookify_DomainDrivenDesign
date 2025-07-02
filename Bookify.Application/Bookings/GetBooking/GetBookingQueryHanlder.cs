
namespace Bookify.Application.Bookings.GetBooking;
internal sealed class GetBookingQueryHanlder(
    IBookingRepository _bookingRepository) 
    : IQueryHandler<GetBookingQuery, BookingResponse>
{
    public async Task<Result<BookingResponse>> Handle(GetBookingQuery request,
        CancellationToken cancellationToken)
    {
        Booking? booking = await _bookingRepository
            .GetByIdAsync(request.BookingId, cancellationToken);

        if (booking is null)
        {
            return Result.Failure<BookingResponse>(BookingErrors.NotFound);            
        }

        var bookingResponse = new BookingResponse()
        {
            Id = booking.Id,
            UserId = booking.UserId,
            ApartmentId = booking.ApartmentId,
            Status = (int)booking.Status,
            AmenitiesUpChargeAmount = booking.AmenitiesUpCharge.Amount,
            AmenitiesUpChargeCurrency = booking.AmenitiesUpCharge.Currency.Code,
            CleaningFeeAmount = booking.CleaningFee.Amount,
            CleaningFeeCurrency = booking.CleaningFee.Currency.Code,
            PriceAmount = booking.PriceForPeriod.Amount,
            PriceCurrency = booking.PriceForPeriod.Currency.Code,
            TotalPriceAmount = booking.TotalPrice.Amount,
        };

        return Result.Success(bookingResponse);

    }
}
