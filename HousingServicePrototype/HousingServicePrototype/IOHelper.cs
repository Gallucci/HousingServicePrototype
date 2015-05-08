using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingServicePrototype
{
    static class IOHelper
    {
        public static void WriteObjectProperties<T>(T obj)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                var name = descriptor.Name;
                var value = descriptor.GetValue(obj);
                Console.WriteLine("{0}={1}", name, value);
            }
        }

        public static string GetProp()
        {
            return "Id1";
        }
    }    
}
