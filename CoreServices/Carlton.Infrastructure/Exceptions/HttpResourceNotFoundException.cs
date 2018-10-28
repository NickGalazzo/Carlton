namespace Carlton.Infrastructure.Exceptions
{
    public class HttpResourceNotFoundException : BaseCarltonException
    {
        public HttpResourceNotFoundException() : base("The server was unable to locate the requested resource")
        {
        }
    }
}
