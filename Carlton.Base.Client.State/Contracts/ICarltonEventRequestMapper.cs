
namespace Carlton.Base.Client.State.Contracts
{
    public interface ICarltonEventRequestMapper<TViewModel>
    {
        GetViewModelRequest<TViewModel> GetViewModelRequest { get; }
        ICarltonComponentRequest<TViewModel> MapToRequest(IComponentEvent<TViewModel> evt);
    }

    public class GetViewModelRequest<TViwModel> : IGetViewModelRequest<TViwModel>
    {
    }
}
