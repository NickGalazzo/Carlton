using System;

namespace Carlton.Base.Client.State.Contracts
{
    public interface ICarltonStateStore<TState>
    {
        event EventHandler<StateChangedEventArgs<TState>> StateChanged;
    }

    public interface ICarltonDataAccessStateStore<TState> : ICarltonStateStore<TState>
    {
        TState GetState();
        void ReplaceState(TState state);
    }

    public class CarltonBaseStateStore<TState> : ICarltonStateStore<TState>
    {
        public event EventHandler<StateChangedEventArgs<TState>> StateChanged;

        private TState _state;

        public TState GetState()
        {
            return _state;
        }

        public void ReplaceState(TState state)
        {
            var args = new StateChangedEventArgs<TState>(_state, state);
            _state = state;
            StateChanged.Invoke(this, args);
        }
    }

    public class StateChangedEventArgs<TState> : EventArgs
    {
        public TState OriginalState { get; private set; }
        public TState ModifiedState { get; private set; }

        public StateChangedEventArgs(TState originalState, TState modifiedState)
        {
            OriginalState = originalState;
            ModifiedState = modifiedState;
        }
    }
}
