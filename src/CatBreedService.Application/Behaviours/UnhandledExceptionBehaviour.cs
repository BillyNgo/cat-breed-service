using MediatR;
using Microsoft.Extensions.Logging;

namespace CatBreedService.Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {

        private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return next();
            }
            catch (Exception ex)
            {
                LogException(ex, LogLevel.Error, request);
                throw;
            }
        }

        private void LogException(Exception ex, LogLevel level, TRequest request)
        {
            _logger.Log(
                level,
                ex,
                "CatBreedService: {ExceptionType} for Request {Name} {@Request}",
                ex.GetType().Name,
                typeof(TRequest).Name,
                request);
        }

    }
}
