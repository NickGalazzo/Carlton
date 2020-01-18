using System;

namespace Carlton.Client.Base.Data
{
    public interface IReadOnlyDataService<TViewModel> 
    {
        event EventHandler<ViewModelChangedEventArgs> ViewModelChanged;
        TViewModel GetViewModel();
    }
}
