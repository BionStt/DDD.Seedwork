using NUnit.Framework;
using System.Collections.Generic;

namespace DDD.Seedwork.UnitTests
{
    public class EntityBaseTests
    {
        class EntityMock : EntityBase
        {
        }

        [Test]
        public void EntityBase_NewInstance_NotEqualsToNull()
        {
            var entityMock = new EntityMock();

            Assert.That(entityMock != null);
        }

        [Test]
        public void EntityBase_TwoSameInstances_Equals()
        {
            var entityMock = new EntityMock();
            var anotherEntityMock = entityMock;

            Assert.That(entityMock == anotherEntityMock);
        }

        [Test]
        public void EntityBase_TwoInstances_NotEquals()
        {
            var entityMock1 = new EntityMock();
            var entityMock2 = new EntityMock();

            Assert.That(entityMock1 != entityMock2);
        }

        [Test]
        public void EntityBase_InstanceInList_BeFound()
        {
            var entityMock = new EntityMock();
            var lookup = new List<EntityMock>
            {
                entityMock,
                new EntityMock(),
                new EntityMock()
            };

            Assert.That(lookup.Contains(entityMock));
        }

        [Test]
        public void EntityBase_InstanceNotInList_NotFound()
        {
            var entityMock = new EntityMock();
            var lookup = new List<EntityMock>
            {
                new EntityMock(),
                new EntityMock(),
                new EntityMock()
            };

            Assert.That(!lookup.Contains(entityMock));
        }
    }
}
