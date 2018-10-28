using System;
using System.Net.Http;

namespace Carlton.Infrastructure.Exceptions
{
    public class CarltonRemoteServerException : BaseCarltonException
    {
        private static readonly string ExceptionMessage = "Error occured while trying to reach remote microservice: {0}";
        public HttpResponseMessage ResponseMessage {get;}

        public CarltonRemoteServerException(HttpResponseMessage responseMessage, Exception innerException) : 
            base(string.Format(ExceptionMessage, GetRemoteServer(responseMessage)), innerException)
        {
            ResponseMessage = responseMessage;
        }

        private static string GetRemoteServer(HttpResponseMessage message)
        {
            return message.RequestMessage.RequestUri.ToString();
        }
    }
}
