using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task_In_Cloud.Shared
{
    public static class Json<T> where T : class
    {
        public static string Serializar(T Object)
        {
            return JsonSerializer.Serialize(Object);
        }

        public static T Deserializar(string Object)
        {
            return JsonSerializer.Deserialize<T>(Object);
        }
    }
}
