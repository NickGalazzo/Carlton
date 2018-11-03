using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Carlton.Config.Data.Models.Config;
using Carlton.Infrastructure.Data.Repository.Base;
using Carlton.Infrastructure.Data.Repository.Dapper;
using Carlton.Infrastructure.Data.Repository.Dapper.Contracts;

namespace Carlton.Config.Database.Repositories
{
    public class ResourceRepository : IRepository<Resource, int>
    {
        public Task Delete(Resource entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Resource>> Find()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Resource>> Find(ISprocSpecification<Resource> specification)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Resource>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Resource> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Resource> FindById<IdType>(IdType id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Resource entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Resource entity)
        {
            throw new NotImplementedException();
        }
    }
}
