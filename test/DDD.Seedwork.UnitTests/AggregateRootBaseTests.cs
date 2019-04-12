using NUnit.Framework;
using System.Linq;

namespace DDD.Seedwork.UnitTests
{
    public class AggregateRootBaseTests
    {
        class MockAggregateRoot : AggregateRootBase { }
        class MockDomainEvent : DomainEventBase { }

        [Test]
        public void AggregateRootBase_WhenInitialized_NoEvent()
        {
            var mockAggregateRoot = new MockAggregateRoot();

            Assert.That(mockAggregateRoot.Events.Count() == 0);
        }

        [Test]
        public void AggregateRootBase_AddEvent_EventAdded()
        {
            var mockAggregateRoot = new MockAggregateRoot();
            var mockEvent = new MockDomainEvent();

            int initialCount = mockAggregateRoot.Events.Count();

            mockAggregateRoot.AddEvent(mockEvent);

            int afterCount = mockAggregateRoot.Events.Count();

            Assert.That(initialCount == 0 && afterCount == 1);
        }

        [Test]
        public void AggregateRootBase_ClearEvents_EventsCleared()
        {
            var mockAggregateRoot = new MockAggregateRoot();
            var mockEvent = new MockDomainEvent();

            mockAggregateRoot.AddEvent(mockEvent);

            int initialCount = mockAggregateRoot.Events.Count();

            mockAggregateRoot.ClearEvents();

            int afterCount = mockAggregateRoot.Events.Count();

            Assert.That(initialCount == 1 && afterCount == 0);
        }
    }
}
