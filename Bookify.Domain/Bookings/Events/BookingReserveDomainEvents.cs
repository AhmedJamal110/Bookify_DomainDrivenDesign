﻿using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;
public sealed record BookingReserveDomainEvents(Guid Id) : IDomainEvents
{

}
