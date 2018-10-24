using System;
using System.Runtime.Serialization;

namespace Carlton.Infrastructure.Exceptions
{
    public class BaseCarltonException : Exception
    {
        public BaseCarltonException()
        {
        }

        public BaseCarltonException(string message) : base(message)
        {
        }

        public BaseCarltonException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BaseCarltonException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
