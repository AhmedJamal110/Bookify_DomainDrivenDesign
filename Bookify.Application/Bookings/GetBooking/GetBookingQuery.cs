﻿namespace Bookify.Application.Bookings.GetBooking;
public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;
