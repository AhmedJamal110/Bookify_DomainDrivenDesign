﻿namespace Bookify.Application.Bookings.GetBooking;
public sealed record BookingResponse
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public Guid ApaermentId { get; }
    public Guid ApartmentId { get; init; }
    public int Status { get; init; }

    public decimal PriceAmount { get; init; }
    public string PriceCurrency { get; init; }

    public decimal CleaningFeeAmount { get; init; }
    public string CleaningFeeCurrency { get; init; }


    public decimal AmenitiesUpChargeAmount { get; init; }
    public string AmenitiesUpChargeCurrency { get; init; }

    public decimal TotalPriceAmount { get; init; }

   
}
