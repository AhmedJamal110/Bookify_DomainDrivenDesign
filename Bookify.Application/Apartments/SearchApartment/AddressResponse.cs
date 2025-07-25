﻿namespace Bookify.Application.Apartments.SearchApartment;
public sealed record AddressResponse
{
    public string Country {get; init;}
    public string State { get; init; }
    public string ZipCode { get; init;}
    public string City { get; init; }

    public string Street { get; init; }
}
