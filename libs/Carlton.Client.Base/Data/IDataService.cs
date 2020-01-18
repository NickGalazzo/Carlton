

namespace Carlton.Client.Base.Data
{
    public interface IDataService<TViewModel> : IReadOnlyDataService<TViewModel>
    {
        void ReplaceSate(TViewModel viewModel);
    }
}
