using System;

namespace Carlton.Base.Infrastructure.Client.Data
{
    public interface IReadOnlyDataService<TViewModel> 
    {
        event EventHandler<ViewModelChangedEventArgs> ViewModelChanged;
        TViewModel GetViewModel();
    }
}
