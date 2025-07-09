using Bookify.Application.Bookings.GetBooking;
using Bookify.Application.Bookings.ReserveBooking;
using Bookify.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.API.Controllers.Bookings;

[ApiController]
[Route("booking")]
public sealed class BookingsController(
    ISender _sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {

        Result<BookingResponse> result = await _sender.Send(new GetBookingQuery(id), cancellationToken);

        return result.IsSuccess
            ? Ok(result) 
            : BadRequest(result);
    }

    [HttpPost]
    public async Task<IActionResult> ReserveBooking(
        ReserveBookingRequest request,
        CancellationToken cancellationToken
        )
    {
        Result<Guid> result = await _sender.Send(new ReserveBookingCommand(
            request.ApartmentId,
            request.UserId,
            request.StartDate,
            request.EndDate
            ), cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(Get) , new {id = result.Value }, result.Value);

    }




}
