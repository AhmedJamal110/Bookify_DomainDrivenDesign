﻿using Bookify.Domain.Apartments;

namespace Bookify.Application.Apartments.SearchApartment;

public sealed record ApartmentResponse
{
    public Guid Id { get; init; }
    public string Name { get;  init; } 
    public string Description { get;  init; } 
    public decimal Price { get;  init; }
    public string Currency { get; init; }
    public AddressResponse Address { get;  init; } 
}
