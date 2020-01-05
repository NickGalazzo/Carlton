using Carlton.Infrastructure.Resiliance;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using Polly.Wrap;

namespace Carlton.Infrastructure.Interceptors
{
    public class ResilianceInterceptor<T> : BaseInterceptor
        where T : PolicyWrap
    {
        private readonly ILogger<ResilianceInterceptor<T>> _logger;
        private readonly IResiliancePolicyHandler<T> _handler;

        public ResilianceInterceptor(ILogger<ResilianceInterceptor<T>> logger, IResiliancePolicyHandler<T> handler)
        {
            _logger = logger;
            _handler = handler;
        }

        public override void InterceptBehavior(IInvocation invocation)
        {
            _logger.LogDebug($"Invoking method {invocation.Method.Name} with resiliant policy");

            var policyResult = _handler.CreatePolicyWrap()
                                       .ExecuteAndCapture(() =>
                                       {
                                           invocation.Proceed();
                                           var result = (T)invocation.ReturnValue;
                                           return result;
                                       });

            _logger.LogDebug($"Finished invoking method {invocation.Method.Name} with resiliant policy");
            _handler.HandleResult(policyResult);
        }
    }
}
