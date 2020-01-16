using Carlton.Base.Data;
using System;

namespace Carlton.Client.Base.Data
{
    public interface IDataService<TViewModel> : IReadOnlyDataService<TViewModel>
        where TViewModel : IViewModel
    {
        void ReplaceSate(TViewModel viewModel);
    }
}
