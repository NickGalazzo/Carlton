using Microsoft.AspNetCore.Components;

namespace Carlton.Base.Client.Components.Data
{
    public interface ICarltonComponent<TViewModel>
    {
        public TViewModel ViewModel { get; set; }
        public EventCallback OnComponentEvent { get; set; }
    }
}
