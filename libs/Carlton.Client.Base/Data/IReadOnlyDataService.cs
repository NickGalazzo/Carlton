using System;

namespace Carlton.Base.Infastructure.Client.Data
{
    public interface IReadOnlyDataService<TViewModel> 
    {
        event EventHandler<ViewModelChangedEventArgs> ViewModelChanged;
        TViewModel GetViewModel();
    }
}
