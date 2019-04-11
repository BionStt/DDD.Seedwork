using System.Collections.Generic;

namespace DDD.Seedwork
{
    public interface IValueObject
    {
        IEnumerable<object> GetAtomicValues();
    }
}
