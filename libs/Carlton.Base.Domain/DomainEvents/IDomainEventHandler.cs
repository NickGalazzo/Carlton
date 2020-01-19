using MediatR;

namespace Carlton.Domain.DomainEvents
{
    public interface IDomainEventHandler : INotificationHandler<IDomainEvent>
    {
    }
}
