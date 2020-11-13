

namespace Carlton.Base.Client.State.Contracts
{
    public interface ICarltonRefreshCondition<TState, TViewModel> 
    {
        bool ShouldRefreshState(StateChangedEventArgs<TState> args);
    }
}
