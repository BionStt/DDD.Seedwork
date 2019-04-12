using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DDD.Seedwork.Extensions
{
    public static class DomainEventExtensions
    {
        public static string GetDisplayName(this IDomainEvent domainEvent)
        {
            var displayName = domainEvent.GetType()
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;

            if (displayName != null)
            {
                return displayName.Name;
            }

            return domainEvent.GetType().Name;
        }
    }
}
