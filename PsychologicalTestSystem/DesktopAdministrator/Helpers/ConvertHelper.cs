using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAdministrator.Helpers
{
    class ConvertHelper
    {
        public static T Convert<T, TS>(TS item) where T : new()
        {
            var result = new T();

            var properties = typeof(T).GetProperties();

            foreach (var propertyInfo in properties)
            {
                var sourceProp = item.GetType().GetProperty(propertyInfo.Name);

                if (sourceProp != null)
                {
                    var value = sourceProp.GetValue(item);

                    propertyInfo.SetValue(result, value);
                }
            }

            return result;
        }

        public static List<T> ConvertCollection<T, TS>(IEnumerable<TS> items) where T : new()
        {
            var result = new List<T>();

            foreach (var item in items)
            {
                result.Add(Convert<T, TS>(item));
            }

            return result;
        }
    }
}
