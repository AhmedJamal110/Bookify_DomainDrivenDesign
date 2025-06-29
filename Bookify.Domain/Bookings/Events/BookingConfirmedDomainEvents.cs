using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;
public sealed record BookingConfirmedDomainEvents(Guid Id) : IDomainEvents;
