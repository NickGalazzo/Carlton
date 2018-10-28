using Carlton.Infrastructure.Exceptions;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Carlton.Infrastructure.Interceptors
{
    public class ExceptionInterceptor
    {
        private readonly ILogger<ExceptionInterceptor> _logger;
        private readonly IExceptionHandler _handler;

        public ExceptionInterceptor(ILogger<ExceptionInterceptor> logger, IExceptionHandler handler)
        {
            _logger = logger;
            _handler = handler;
        }

        public void Intercept(IInvocation invocation)
        {
            var typeName = nameof(invocation.TargetType);
            var requestObj = invocation.Arguments.First();

            using (_logger.BeginScope(typeName))
                try
                {
                    _logger.LogInformation($"Entering Handler of type: {invocation.TargetType}");
                    invocation.Proceed();
                    _logger.LogInformation($"Exiting Handler of type: {invocation.TargetType}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error occured in handler of type: {typeName}");
                    _handler.HandleException(ex, requestObj);             
                }
        }
    }
}



