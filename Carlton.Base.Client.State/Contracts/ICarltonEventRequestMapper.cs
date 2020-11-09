
namespace Carlton.Base.Client.State.Contracts
{
    public interface ICarltonEventRequestMapper<TViewModel>
    {
        ICarltonComponentRequest<TViewModel> MapToRequest(IComponentEvent evt);
    }
}
