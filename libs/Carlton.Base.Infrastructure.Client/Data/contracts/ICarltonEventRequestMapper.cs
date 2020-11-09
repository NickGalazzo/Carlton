
namespace Carlton.Base.Client.Data
{
    public interface ICarltonEventRequestMapper<TViewModel>
    {
        ICarltonComponentRequest<TViewModel> MapToRequest(IComponentEvent evt);
    }
}
