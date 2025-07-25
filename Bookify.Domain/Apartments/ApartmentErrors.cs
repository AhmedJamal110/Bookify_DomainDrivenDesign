﻿using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Apartments;
public static class ApartmentErrors
{
    public static readonly Error NotFound = new(
       "Apartment.NotFound",
       "The apartment with the specified identifier was not found");

    public static readonly Error ValidationError = new(
       "Apartment.Date",
       "Start date cannot be after end date.");

}
