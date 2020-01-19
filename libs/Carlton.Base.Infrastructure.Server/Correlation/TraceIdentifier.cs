using Microsoft.AspNetCore.Http;

namespace Carlton.Base.Infrastructure.Server.Correlation
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
