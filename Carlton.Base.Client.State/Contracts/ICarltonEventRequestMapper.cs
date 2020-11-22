namespace Carlton.Base.Client.State.Contracts
{
    public interface ICarltonEventRequestMapper
    {
        ICarltonComponentRequest<TViewModel> MapToRequest<TViewModel>(ICarltonComponentEvent evt);
        ICarltonComponentRequest<TViewModel> GetViewModelRequest<TViewModel>();
    }
}
