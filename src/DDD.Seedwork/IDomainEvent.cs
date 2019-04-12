using System;

namespace DDD.Seedwork
{
    public interface IDomainEvent
    {
        DateTime TimeStampUtc { get; }
    }
}
