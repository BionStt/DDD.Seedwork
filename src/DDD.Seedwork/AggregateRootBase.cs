using System.Collections.Generic;

namespace DDD.Seedwork
{
    public abstract class AggregateRootBase : EntityBase, IAggregateRoot
    {
        public string AggregateRootType => this.GetType().FullName;

        private readonly IList<IDomainEvent> _events = new List<IDomainEvent>();
        public IEnumerable<IDomainEvent> Events => _events;

        public void AddEvent(IDomainEvent @event)
        {
            _events.Add(@event);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }
    }
}
