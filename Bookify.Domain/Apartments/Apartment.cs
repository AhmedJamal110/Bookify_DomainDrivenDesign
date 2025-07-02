using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;

namespace Bookify.Domain.Apartments;
public sealed class Apartment(
    Guid id,
    Name name,
    Description description,
    Address address,
    Money price,
    Money cleaningFee,
    List<Amenity> amenities) : BaseEntity(id)
{
    public Name Name { get; private set; } = name;
    public Description Description { get; private set; } = description;
    public Address Address { get; private set; } = address;
    public Money Price { get; private set; } = price;
    public Money CleeningFee { get; private set; } = cleaningFee;
    public DateTime? LastBookedOnUtc  { get; internal set; }
    public List<Amenity> Amenities { get; set; } = amenities;


    public List<Booking> Bookings { get; set; } = [];


}
