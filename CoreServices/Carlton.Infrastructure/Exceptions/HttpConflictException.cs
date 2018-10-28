namespace Carlton.Infrastructure.Exceptions
{
    public class HttpConflictException : BaseCarltonException
    {
        public HttpConflictException() : base("Unable to complete request due to a conflict with the current state of the target resource.")
        {

        }
    }
}
