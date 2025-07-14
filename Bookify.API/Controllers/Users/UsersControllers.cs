using Bookify.Application.Users;
using Bookify.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.API.Controllers.Users;

[ApiController]
[Route("users")]
public sealed class UsersControllers(
    ISender _sender) : ControllerBase
{

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> RegisterUserAsync(
        [FromBody] RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        Result<Guid> result = await _sender.Send(new RegisterUserCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password), cancellationToken);


        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }


        return Ok(result.Value);

    }
}
