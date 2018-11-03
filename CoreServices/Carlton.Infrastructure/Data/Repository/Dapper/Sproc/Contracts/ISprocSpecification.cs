using System.Collections.Generic;

namespace Carlton.Infrastructure.Data.Repository.Dapper.Contracts
{
    public interface ISprocSpecification<T> 
    {
        string SprocName { get; set; }
        Dictionary<string, object> Params { get; set; }
    }
}
