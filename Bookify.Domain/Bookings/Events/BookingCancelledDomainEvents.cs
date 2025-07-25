﻿using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;
public sealed record BookingCancelledDomainEvents(Guid Id) : IDomainEvents;
