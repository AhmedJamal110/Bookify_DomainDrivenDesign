using Bookify.Domain.Apartments;

namespace Bookify.Domain.Bookings;
public sealed class PricingService
{
    public PricingDetails CalculatePricing(Apartment apartment, DateRange period)
    {
        Currency currency = apartment.Price.Currency;

        var priceForPeriod = new Money(apartment.Price.Amount * period.LengthInDays , currency);

        decimal percentageUpCharge = 0;

        foreach (var amenity in apartment.Amenities)
        {
            percentageUpCharge += amenity switch
            {
                Amenity.GardenView or Amenity.MountainView => 0.05m, // 5% upcharge
                Amenity.AirConditioning => 0.01m, // 10% upcharge
                Amenity.Parking => 0.01m, // 15% upcharge
                _ => 0
            };
        }


         var amenityUpCharge = Money.Zero();

        if (percentageUpCharge > 0)
        {
            amenityUpCharge = new Money(priceForPeriod.Amount * percentageUpCharge, currency);
        }

         var totalPrice = Money.Zero();
        
        totalPrice += priceForPeriod;

        if(apartment.CleeningFee.IsZero())
        {
            totalPrice += apartment.CleeningFee;
        }


        totalPrice  += amenityUpCharge;

        return new PricingDetails(priceForPeriod, apartment.CleeningFee!, amenityUpCharge, totalPrice);

    }
}
