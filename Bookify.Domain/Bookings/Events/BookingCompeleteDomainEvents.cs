﻿using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;
public sealed record BookingCompeleteDomainEvents(Guid Id) : IDomainEvents;
