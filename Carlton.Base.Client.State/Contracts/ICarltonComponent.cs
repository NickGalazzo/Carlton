using Microsoft.AspNetCore.Components;

namespace Carlton.Base.Client.State
{
    public interface ICarltonComponent<TViewModel>
    {
        TViewModel ViewModel { get; set; }
        EventCallback<ICarltonComponentEvent> OnComponentEvent { get; set; }
    }
}
