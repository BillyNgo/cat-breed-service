﻿using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace CatBreedService.Application.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //Request
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            var myType = request?.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType?.GetProperties() ?? Array.Empty<PropertyInfo>());
            foreach (var prop in props)
            {
                var propValue = prop.GetValue(request, null);
                _logger.LogInformation("{Property} : {@Value}", prop.Name, propValue);
                // Do something with propValue
            }

            var response = await next();

            //Response
            _logger.LogInformation($"Handled {typeof(TResponse).Name}");
            return response;
        }
    }
}
