using Task_In_Cloud.Shared;

namespace Task_in_Cloud.Infrastructure.Mapper
{
    public static class Mapper
    {
        public static T MapperObject<T>(object Object) where T : new()
        {
            return MapperUtil.Map<T>(Object);
        }

        public static List<T> MapperListObjects<T>(object Objects) where T : new()
        {
            return MapperUtil.Map<List<T>>(Objects);
        }
    }
}
