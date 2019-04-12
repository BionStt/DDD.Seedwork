using System.Collections.Generic;

namespace DDD.Seedwork
{
    public interface IAggregateRoot : IEntity
    {
        string AggregateRootType { get; }
        IEnumerable<IDomainEvent> Events { get; }

        void AddEvent(IDomainEvent @event);
        void ClearEvents();
    }
}
