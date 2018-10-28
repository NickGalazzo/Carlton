using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Carlton.Infrastructure.Interceptors
{
    public class AuditInterceptor : IInterceptor
    {
        private readonly ILogger<AuditInterceptor> _logger;
        private readonly Stopwatch _stopwatch;

        public AuditInterceptor(ILogger<AuditInterceptor> logger)
        {
            _logger = logger;
            _stopwatch = new Stopwatch();
        }

        public void Intercept(IInvocation invocation)
        {
            _stopwatch.Start();
            invocation.Proceed();
            _stopwatch.Stop();
            _logger.LogTrace($"Method: {invocation.Method.Name} finished with elapsed time of {_stopwatch.Elapsed.TotalMilliseconds}");
            _stopwatch.Reset();
        }
    }
}
