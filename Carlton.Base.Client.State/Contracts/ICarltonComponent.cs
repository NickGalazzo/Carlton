using Microsoft.AspNetCore.Components;

namespace Carlton.Base.Client.State.Contracts
{
    public interface ICarltonComponent<TViewModel>
    {
        TViewModel ViewModel { get; set; }
        EventCallback<ICarltonComponentEvent> OnComponentEvent { get; set; }
    }
}
