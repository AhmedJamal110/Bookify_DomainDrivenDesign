﻿using Bookify.Domain.Apartments;
namespace Bookify.Domain.Bookings;
public sealed record PricingDetails(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmetitiesUpCharge,
    Money TotalPrice);
