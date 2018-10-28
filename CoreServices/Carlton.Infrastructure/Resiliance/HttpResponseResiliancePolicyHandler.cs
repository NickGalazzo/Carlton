using Carlton.Infrastructure.Exceptions;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Wrap;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Carlton.Infrastructure.Resiliance
{
    public class HttpResponseResiliancePolicyHandler : IResiliancePolicyHandler<HttpResponseMessage>
    {
        private readonly ILogger<HttpResponseResiliancePolicyHandler> _logger;

        public HttpResponseResiliancePolicyHandler(ILogger<HttpResponseResiliancePolicyHandler> logger)
        {
            _logger = logger;
        }

        public PolicyWrap<HttpResponseMessage> CreatePolicyWrap()
        {
            HttpStatusCode[] httpStatusCodesWorthRetrying = {
               HttpStatusCode.RequestTimeout, // 408
               HttpStatusCode.InternalServerError, // 500
               HttpStatusCode.BadGateway, // 502
               HttpStatusCode.ServiceUnavailable, // 503
               HttpStatusCode.GatewayTimeout // 504
            };

            var policy = Policy
               .Handle<HttpRequestException>()
               .OrResult<HttpResponseMessage>(r => httpStatusCodesWorthRetrying.Contains(r.StatusCode))
               .RetryAsync(3);

            var policyWrap = policy.Wrap(Policy.Timeout(10));

            return policyWrap;
        }

        public void HandleResult(PolicyResult<HttpResponseMessage> policyResult)
        {
            if (policyResult.Outcome == OutcomeType.Failure)
            {
                var requestUrl = policyResult.Result.RequestMessage.RequestUri;
                _logger.LogWarning($"Failed to reach remote server: {requestUrl} with resiliance policy, throwing exception");
                throw new CarltonRemoteServerException(policyResult.Result, policyResult.FinalException);
            }
        }
    }
}
