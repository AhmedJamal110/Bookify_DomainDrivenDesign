using Bookify.Application.Apartments.CreateApartment;
using Bookify.Application.Apartments.SearchApartment;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.API.Controllers.Apartments;

[ApiController]
[Route("apartments")]
public sealed class ApartmentController(
    ISender _sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> SearchApartments(
        DateOnly startDate,
        DateOnly endDate,
        CancellationToken cancellationToken)
    {

        Result<IReadOnlyList<ApartmentResponse>> result = await _sender
            .Send(new SearchAprtmentQuery(startDate, endDate), cancellationToken);


        return Ok(result.Value);

    }

   

}
