using Carlton.Domain.BusinessObjects;
using Carlton.Infrastructure.Exceptions;
using System;

namespace Carlton.Domain.Exceptions
{
    public class DomainException : CarltonBaseException
    {
        private const string ErrMessage = "An error occured inside a business domain object {0}";
        public IDomainObject Obj {get;}

        public DomainException(IDomainObject obj, Exception innerException)
            :base(string.Format(ErrMessage, nameof(obj)), innerException)
        {
            this.Obj = obj;
        }
    }
}
