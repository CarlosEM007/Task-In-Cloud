using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_In_Cloud.Shared.Utils
{
    public static class Mapper
    {
        public static TDestination Map<TDestination>(object source)
            where TDestination : new()
        {
            var dest = new TDestination();

            foreach (var prop in source.GetType().GetProperties())
            {
                var destProp = typeof(TDestination).GetProperty(prop.Name);
                if (destProp != null && destProp.CanWrite)
                {
                    destProp.SetValue(dest, prop.GetValue(source));
                }
            }

            return dest;
        }
    }
}
