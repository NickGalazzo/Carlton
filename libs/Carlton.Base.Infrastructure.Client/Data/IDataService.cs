

namespace Carlton.Base.Infastructure.Client.Data
{
    public interface IDataService<TViewModel> : IReadOnlyDataService<TViewModel>
    {
        void ReplaceSate(TViewModel viewModel);
    }
}
