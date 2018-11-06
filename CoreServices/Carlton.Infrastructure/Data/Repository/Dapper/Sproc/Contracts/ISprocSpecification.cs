namespace Carlton.Infrastructure.Data.Repository.Dapper.Contracts
{
    public interface ISprocSpecification<T, TSprocParams> 
    {
        string SprocName { get; set; }
        TSprocParams Params { get; set; }
    }
}
