using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace Debt_Collection_DATA.Helpers
{
    public static class PatchHelper
    {
        public static void PatchNonNullValues<T>(T source, T destination, DbContext context, params string[] ignoreProperties)
            where T : class
        {
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                // Skip navigation collections
                if (typeof(System.Collections.IEnumerable).IsAssignableFrom(prop.PropertyType) &&
                    prop.PropertyType != typeof(string))
                {
                    continue;
                }

                // Skip ignored properties
                if (ignoreProperties.Contains(prop.Name))
                    continue;

                var newValue = prop.GetValue(source);
                if (newValue != null)
                {
                    prop.SetValue(destination, newValue);
                }
            }

            // Mark ignored properties as not modified
            var entry = context.Entry(destination);
            foreach (var ignore in ignoreProperties)
            {
                entry.Property(ignore).IsModified = false;
            }
        }
    }
}
