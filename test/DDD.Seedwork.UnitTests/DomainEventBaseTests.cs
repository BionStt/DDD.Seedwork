using DDD.Seedwork.Extensions;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace DDD.Seedwork.UnitTests
{
    public class DomainEventBaseTests
    {
        class ItemCreated : DomainEventBase { }

        [Display(Name = "Another Item Created")]
        class AnotherItemCreated : DomainEventBase { }

        [Test]
        public void DomainEventBase_WithoutDisplayName_ReturnsClassName()
        {
            var itemCreated = new ItemCreated();

            string displayName = itemCreated.GetDisplayName();

            Assert.That(displayName == "ItemCreated");
        }

        [Test]
        public void DomainEventBase_WithDisplayName_ReturnsDisplayName()
        {
            var itemCreated = new AnotherItemCreated();

            string displayName = itemCreated.GetDisplayName();

            Assert.That(displayName == "Another Item Created");
        }
    }
}
