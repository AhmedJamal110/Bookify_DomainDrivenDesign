using System.Xml.Linq;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;
using Bookify.Domain.Reviews.Events;

namespace Bookify.Domain.Reviews;
public sealed class Review : BaseEntity
{
    public Review(
        Guid id,
        Guid userId,
        Guid appartmentId,
        Guid bookingId,
        Rating rating,
        Comment comment,
        DateTime createOnUtc):base(id)
    {
        UserId = userId;
        AppartmentId = appartmentId;
        BookingId = bookingId;
        Rating = rating;
        Comment = comment;
        CreatedOnUtc = createOnUtc;
    }

    public Review()
    {
        
    }

    public Guid UserId { get; set; }
    public Guid AppartmentId { get; set; }
    public Guid BookingId { get; set; }

    public Rating Rating { get; private set; }

    public Comment Comment { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public static Result<Review> Create(
        Booking booking,
        Rating rating,
        Comment comment,
        DateTime createdOnUtc)
    {
        if(booking.Status != BookingStatus.Completed)
        {
            return Result.Failure<Review>(ReviewErrors.NotEligible);
        }
    
        var review = new Review(
            Guid.NewGuid(),
            booking.UserId,
            booking.ApaermentId,
            booking.Id,
            rating,
            comment,
            createdOnUtc
            );

        review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));

        return Result.Success(review);

    }

}
