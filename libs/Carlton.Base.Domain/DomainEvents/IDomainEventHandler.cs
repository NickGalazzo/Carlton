using MediatR;

namespace Carlton.Base.Domain.DomainEvents
{
    public interface IDomainEventHandler : INotificationHandler<IDomainEvent>
    {
    }
}
