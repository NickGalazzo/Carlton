

namespace Carlton.Base.Infrastructure.Client.Data
{
    public interface IDataService<TViewModel> : IReadOnlyDataService<TViewModel>
    {
        void ReplaceSate(TViewModel viewModel);
    }
}
