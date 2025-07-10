using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.API.Middelwares;

public sealed class GlobalExceptionHandler(
    IProblemDetailsService _problemDetailsService,
    IHostEnvironment _environment) : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {

        return _problemDetailsService.TryWriteAsync(new ProblemDetailsContext()
        {
            Exception = exception,
            HttpContext = httpContext,
            ProblemDetails = new ProblemDetails()
            {
                Title = "Internal Server Error",
                Detail = _environment.IsDevelopment()
                    ? exception.Message
                    : "An unexpected error occurred. Please try again later."
            }
        });



    }

}
