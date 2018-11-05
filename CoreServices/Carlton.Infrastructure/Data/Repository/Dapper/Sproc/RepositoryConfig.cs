namespace Carlton.Infrastructure.Data.Repository.Dapper.Sproc
{
    public abstract class RepositoryConfig<T>
    {
        public SprocRepositoryOptions<T> Options { get; private set; }

        public RepositoryConfig(SprocRepositoryOptionsBuilder<T> builder)
        {
            ConfigureSprocs(Options, builder);
        }

        public abstract void ConfigureSprocs(SprocRepositoryOptions<T> Options, SprocRepositoryOptionsBuilder<T> builder);
    }
}
