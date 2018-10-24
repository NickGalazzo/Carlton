using Carlton.Domain.Commands;
using Carlton.Domain.Exceptions;
using Carlton.Domain.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Carlton.Domain.Behaviors
{
    public class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<ExceptionBehavior<TRequest, TResponse>> _logger;

        public ExceptionBehavior(ILogger<ExceptionBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestType = request.GetType();

            using (_logger.BeginScope(requestType))
            {
                try
                {
                    _logger.LogInformation($"Entering Handler of type: {requestType}");
                    var result = next();
                    _logger.LogInformation($"Exiting Handler of type: {requestType}");
                    return await result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error occured in Repository of type: {requestType}");

                    switch (request)
                    {
                        case ICommand c:
                            throw new CommandException(c, $"Error occured while executing command {requestType}", ex);
                        case IQuery q:
                            throw new QueryException(q, $"Error occured while executing query {requestType}", ex);
                        default:
                            throw new ArgumentException("Request is neither a command nor query; this should never happen");
                    }  
                }
            }
        }
    }
}

