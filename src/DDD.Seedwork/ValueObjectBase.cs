using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Seedwork
{
    public abstract class ValueObjectBase : IValueObject, IEquatable<ValueObjectBase>
    {
        public bool Equals(ValueObjectBase other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            IEnumerator<object> thisValues = this.GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^
                    ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current != null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }

            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ValueObjectBase);
        }

        public override int GetHashCode()
        {
            return this.GetAtomicValues()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public static bool operator ==(ValueObjectBase left, ValueObjectBase right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObjectBase left, ValueObjectBase right)
        {
            return !(left == right);
        }

        public abstract IEnumerable<object> GetAtomicValues();
    }
}
