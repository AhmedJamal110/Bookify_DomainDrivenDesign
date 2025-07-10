using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.API.Middelwares;

public sealed class ValidationExceptionHandler(
    IProblemDetailsService _problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
        {
            return false; 
        }

        var errors = validationException.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key.ToLowerInvariant(),
                g => g.Select(e => e.ErrorMessage).ToArray());

        ProblemDetailsContext problemDetailsContext = new()
        {
            Exception = exception,
            HttpContext = httpContext,
            ProblemDetails = new ProblemDetails()
            {
                Title = "Validation Server Error",
                Detail = "An Validation error occurred.",
                Status = StatusCodes.Status400BadRequest,
            }
        };

        problemDetailsContext.ProblemDetails.Extensions.Add("errors", errors);


        return  await _problemDetailsService.TryWriteAsync(problemDetailsContext);



    }
}
