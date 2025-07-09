using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;

namespace Bookify.API.Controllers.Apartments;

public sealed record CreateApartmentRequest(
    string Name,
    string Description,
    string Country,
    string State,
    string Zip,
    string Street,
    string City,
    decimal PriceAmount,
    string PriceCurrency,
    decimal CleaningFeeAmount,
    string CleaningFeeCurrency);
