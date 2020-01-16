using Carlton.Base.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carlton.Client.Base.Data
{
    public interface IReadOnlyDataService<TViewModel> where TViewModel : IViewModel
    {
        event EventHandler<ViewModelChangedEventArgs> ViewModelChanged;
        TViewModel GetViewModel();
    }
}
