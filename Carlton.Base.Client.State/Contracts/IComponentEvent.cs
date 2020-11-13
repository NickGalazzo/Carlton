using MediatR;

namespace Carlton.Base.Client.State.Contracts
{
    public interface IComponentEvent<TViewModel>
    {
        string ViewModelName { get { return nameof(TViewModel); } }
        string EventName { get { return GetType().Name; } }
    }
}
