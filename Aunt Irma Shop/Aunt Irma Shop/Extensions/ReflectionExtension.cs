using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aunt_Irma_Shop.Extensions
{
    public static class ReflectionExtension
    {
        public static string GetPropertyValue<T>(this T item, string propertyName)
        {
            return item.GetType().GetProperty(propertyName).GetValue(item, null).ToString();
        }
    }
}
