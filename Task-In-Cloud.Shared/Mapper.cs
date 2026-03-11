namespace Task_In_Cloud.Shared
{
    public static class MapperUtil
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
