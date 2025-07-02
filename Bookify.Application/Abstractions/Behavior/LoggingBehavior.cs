
using Microsoft.Extensions.Logging;

namespace Bookify.Application.Abstractions.Behavior;
public sealed class LoggingBehavior<TRequest, TResponse>(ILogger _logger) 
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {

        string name = request.GetType().Name;

        try
        {
            _logger.LogInformation("Excuting Command {Command}", name);

            TResponse? response = await next(cancellationToken);

            _logger.LogInformation("Command {Command} Processed Successfully", name);

            return response;
        }

        catch (Exception ex)
        {
            _logger.LogError( ex , "Command {Command} Processed Filled", name);
            throw;
        }

    }
}
