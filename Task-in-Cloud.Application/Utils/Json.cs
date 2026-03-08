using System.Text.Json;

namespace Task_In_Cloud.Shared.Utils
{
    public static class Json<T> where T : class
    {
        public static string Serializar(T Object)
        {
            return JsonSerializer.Serialize(Object);
        }

        public static T? Deserializar(string Object)
        {
            return JsonSerializer.Deserialize<T>(Object);
        }
    }
}
