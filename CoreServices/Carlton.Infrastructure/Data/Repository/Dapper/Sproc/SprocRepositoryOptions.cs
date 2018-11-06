using System;
using System.Collections.Generic;

namespace Carlton.Infrastructure.Data.Repository.Dapper
{
    public class SprocRepositoryOptions<T>
    {
        public Dictionary<string, string> CrudSprocMap { get; }
        public string IdParameter { get; }
        public Delegate Map { get; }
     

        public SprocRepositoryOptions(Dictionary<string, string> crud, string idParameter, Delegate map)
        {
            CrudSprocMap = crud;
            IdParameter = idParameter;
            Map = map;
        }
    }
}
