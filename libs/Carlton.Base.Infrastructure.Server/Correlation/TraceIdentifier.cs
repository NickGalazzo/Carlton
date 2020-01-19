using Microsoft.AspNetCore.Http;

namespace Carlton.Infrastructure.Correlation
{
    public class TraceIdentifier
    {
        public string Value { get; }

        public TraceIdentifier(IHttpContextAccessor contextAccessor)
        {
            Value = contextAccessor.HttpContext.TraceIdentifier;
        }
    }
}
