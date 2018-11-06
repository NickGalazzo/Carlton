using Carlton.Config.Data.Models.Config;
using Carlton.Infrastructure.Data.Repository.Dapper;
using Carlton.Infrastructure.Data.Repository.Dapper.Sproc;
using Carlton.Registry.Data.Models.Config;

namespace Carlton.Config.Data.SprocInfos.Resources
{
    public class ResouceRepositoryConfig : RepositoryConfig<Resource>
    {
        public ResouceRepositoryConfig(SprocRepositoryOptionsBuilder<Resource> builder) : base(builder)
        {
        }

        public override void ConfigureSprocs(SprocRepositoryOptions<Resource> Options, SprocRepositoryOptionsBuilder<Resource> builder)
        {
            var options =
                builder
                .WithStandardCrudConventions()
                .WithMap<Resource, ResourceType, ResourceStatus, Resource>((o, oo, ooo) =>
                {
                    return new Resource();
                }, "ResourceTypeId", "ResourceStatusId", "ResourcesEnviornmentId")
                .Build();
        }
    }
}
