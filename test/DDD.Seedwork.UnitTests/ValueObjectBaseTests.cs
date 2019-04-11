using NUnit.Framework;
using System.Collections.Generic;

namespace DDD.Seedwork.UnitTests
{
    public class ValueObjectBaseTests
    {
        class ShortAddress : ValueObjectBase
        {
            public string AddressLine { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }

            public override IEnumerable<object> GetAtomicValues()
            {
                yield return AddressLine;
                yield return City;
                yield return State;
                yield return Zip;
            }
        }

        class FullAddress : ValueObjectBase
        {
            public string Label { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
            public string County { get; set; }
            public string Country { get; set; }

            public override IEnumerable<object> GetAtomicValues()
            {
                yield return Label;
                yield return AddressLine1;
                yield return AddressLine2;
                yield return City;
                yield return State;
                yield return Zip;
                yield return County;
                yield return Country;
            }
        }

        [Test]
        public void ValueObjectBase__NewInstance_NotEqualsToNull()
        {
            var valueObjectMock = new ShortAddress
            {
                AddressLine = "12345 SE 67th Ave",
                City = "Portland",
                State = "OR",
                Zip = "97266"
            };

            Assert.That(valueObjectMock != null);
        }

        [Test]
        public void ValueObjectBase__SamePropertiesWithSameValues_Equals()
        {
            var valueObjectMock1 = new ShortAddress
            {
                AddressLine = "12345 SE 67th Ave",
                City = "Portland",
                State = "OR",
                Zip = "97266"
            };

            var valueObjectMock2 = new ShortAddress
            {
                AddressLine = "12345 SE 67th Ave",
                City = "Portland",
                State = "OR",
                Zip = "97266"
            };

            Assert.That(valueObjectMock1 == valueObjectMock2);
        }

        [Test]
        public void ValueObjectBase__SamePropertiesWithDifferentValues_NotEquals()
        {
            var valueObjectMock1 = new ShortAddress
            {
                AddressLine = "12345 SE 67th Ave",
                City = "Portland",
                State = "OR",
                Zip = "97266"
            };

            var valueObjectMock2 = new ShortAddress
            {
                AddressLine = "12345 SE 67th Ave",
                City = "Portland",
                State = "OR"
            };

            Assert.That(valueObjectMock1 != valueObjectMock2);
        }

        [Test]
        public void ValueObjectBase__DifferentPropertiesWithSameValues_NotEquals()
        {
            var valueObjectMock1 = new ShortAddress
            {
                City = "Portland",
                State = "OR",
                Zip = "97266"
            };

            var valueObjectMock2 = new FullAddress
            {
                City = "Portland",
                State = "OR",
                Zip = "97266"
            };

            Assert.That(valueObjectMock1 != valueObjectMock2);
        }

        [Test]
        public void ValueObjectBase_InstanceNotInList_NotFound()
        {
            var valueObjectMock = new ShortAddress
            {
                City = "Portland",
                State = "OR",
                Zip = "97266"
            };

            var lookup = new List<ShortAddress>
            {
                new ShortAddress
                {
                    AddressLine = "12345 SE 67th Ave",
                    City = "Portland",
                    State = "OR",
                    Zip = "97266"
                },
                new ShortAddress
                {
                    City = "Portland",
                    State = "OR",
                    Zip = "97267"
                },
                new ShortAddress()
            };

            Assert.That(!lookup.Contains(valueObjectMock));
        }

        [Test]
        public void ValueObjectBase_InstanceInList_BeFound()
        {
            var valueObjectMock = new ShortAddress
            {
                City = "Portland",
                State = "OR",
                Zip = "97266"
            };

            var lookup = new List<ShortAddress>
            {
                new ShortAddress
                {
                    AddressLine = "12345 SE 67th Ave",
                    City = "Portland",
                    State = "OR",
                    Zip = "97266"
                },
                new ShortAddress
                {
                    City = "Portland",
                    State = "OR",
                    Zip = "97267"
                },
                new ShortAddress(),
                valueObjectMock
            };

            Assert.That(lookup.Contains(valueObjectMock));
        }
    }
}
