using MediatR;

namespace Carlton.Base.Infastructure.Client.Events
{
    public interface IComponentEvent<T> : IRequest<T>
        where T : IComponentEventResult
    {
    }
}
