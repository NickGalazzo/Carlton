using Microsoft.AspNetCore.Components;

namespace Carlton.Base.Client.Data
{
    public interface ICarltonComponent<TViewModel>
    {
        public TViewModel ViewModel { get; set; }
        public EventCallback OnComponentEvent { get; set; }
    }
}
