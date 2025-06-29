using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings.Events;

namespace Bookify.Domain.Bookings;
public sealed class Booking : BaseEntity
{
    public Booking(

        Guid id,
        Guid userId,
        Guid apaermentId,
        DateRange duration,
        Money priceForPeriod,
        Money cleaningFee,
        Money amenitiesUpCharge,
        Money totalPrice,
        BookingStatus status,
        DateTime createdOnUtc) : base(id)
    {
        UserId = userId;
        ApaermentId = apaermentId;
        Duration = duration;
        PriceForPeriod = priceForPeriod;
        CleaningFee = cleaningFee;
        AmenitiesUpCharge = amenitiesUpCharge;
        TotalPrice = totalPrice;
        Status = status;
        CreatedOnUtc = createdOnUtc;
    }

    public Guid UserId { get; private set; }
    public Guid ApaermentId { get; }
    public Guid ApartmentId { get; private set; }

    public DateRange Duration { get; private set; }

    public Money PriceForPeriod { get; private set; }
    public Money CleaningFee { get; private set; }
    public Money AmenitiesUpCharge { get; private set; }
    public Money TotalPrice { get; private set; }

    public BookingStatus Status { get; private set; }


    public DateTime CreatedOnUtc { get; private set; } 
    public DateTime? ConfirmedOnUtc { get; private set; } 
    public DateTime? RefectedOnUtc { get; private set; } 
    public DateTime? CompeletedOnUtc { get; private set; } 
    public DateTime? CancelledOnUtc { get; private set; } 


    public static Booking Reserve(
        Apartment apartment,
        Guid userId,
        DateRange duration,
        DateTime dateTime,
        PricingService pricingService)
    {

        PricingDetails pricingDetails = pricingService.CalculatePricing(apartment, duration);

        var booking = new Booking(
            Guid.CreateVersion7(),
            userId,
            apartment.Id,
            duration,
            pricingDetails.PriceForPeriod,
            pricingDetails.CleaningFee,
            pricingDetails.AmetitiesUpCharge,
            pricingDetails.TotalPrice,
            BookingStatus.Reserved,
            dateTime
            );

        booking.RaiseDomainEvent(new BookingReserveDomainEvents(booking.Id));

        apartment.LastBookedOnUtc = dateTime;


        return booking;

    }



    public Result Confirm(DateTime dateTime)
    {
        if (Status != BookingStatus.Reserved)
        {
            return Result.Failure(BookingErrors.NotReserved);
        }

        Status = BookingStatus.Confirmed;
        ConfirmedOnUtc = dateTime;
        
        RaiseDomainEvent(new BookingConfirmedDomainEvents(Id));
        
        return Result.Success();
    }

    public Result Reject(DateTime dateTime)
    {
        if (Status != BookingStatus.Reserved)
        {
            return Result.Failure(BookingErrors.NotReserved);
        }
        Status = BookingStatus.Rejected;
        RefectedOnUtc = dateTime;
        RaiseDomainEvent(new BookingRejectedDomainEvents(Id));
        return Result.Success();
    }


    public Result Complete(DateTime dateTime)
    {
        if (Status != BookingStatus.Confirmed)
        {
            return Result.Failure(BookingErrors.NotConfirmed);
        }
        Status = BookingStatus.Completed;
        RefectedOnUtc = dateTime;
        RaiseDomainEvent(new BookingCompeleteDomainEvents(Id));
        return Result.Success();
    }

    public Result Cancel(DateTime dateTime)
    {
        if (Status != BookingStatus.Confirmed)
        {
            return Result.Failure(BookingErrors.NotConfirmed);
        }

        var currentDate = DateOnly.FromDateTime(dateTime);

        if (currentDate > Duration.Start)
        {
            return Result.Failure(BookingErrors.AlreadyStarted);
        }

        Status = BookingStatus.Cancelled;
        RefectedOnUtc = dateTime;
        RaiseDomainEvent(new BookingCancelledDomainEvents(Id));
        return Result.Success();
    }




}
