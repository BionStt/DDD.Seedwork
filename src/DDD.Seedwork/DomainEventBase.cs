using System;

namespace DDD.Seedwork
{
    public abstract class DomainEventBase : IDomainEvent
    {
        public DateTime TimeStampUtc { get; private set; } = DateTime.UtcNow;
    }
}
