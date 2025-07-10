using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Emit;
using Bogus;
using Bookify.Domain.Apartments;
using Bookify.Domain.Users;
using Bookify.Infrastructre.Database;

namespace Bookify.API.Extensions;

public static class SeedingDataExtensions
{
    public static void SeedData(this WebApplication app)
    {
        using IServiceScope serviceScope = app.Services.CreateScope();

        using ApplicationDbContext dbContext = serviceScope
            .ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        var faker = new Faker();

        if (!dbContext.Apartments.Any())
        {
            for (var i = 0; i < 100; i++)
            {
                var address = new Address(
                    faker.Address.Country(),
                    faker.Address.State(),
                    faker.Address.ZipCode(),
                    faker.Address.City(),
                    faker.Address.StreetAddress());

                var price = new Money(
                    faker.Random.Decimal(50, 500),
                    Currency.USD);

                var cleaningFee = new Money(
                    faker.Random.Decimal(10, 100),
                    Currency.USD);

                var name = new Name(faker.Company.CompanyName());
                var description = new Description(faker.Lorem.Sentence());

                var amenities = new List<Amenity>
                {
                    faker.PickRandom<Amenity>(),
                    faker.PickRandom<Amenity>()
                };

                var apartment = new Apartment(
                    Guid.NewGuid(),
                    name,
                    description,
                    address,
                    price,
                    cleaningFee,
                    amenities);

                dbContext.Apartments.Add(apartment);
            }

            dbContext.SaveChanges();
        }
    }
}
