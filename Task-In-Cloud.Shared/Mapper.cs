namespace Task_In_Cloud.Shared
{
    public static class MapperUtil
    {
        public static TDestination Map<TSource, TDestination>(TSource source)
            where TDestination : new()
        {
            if (source == null)
                return default!;

            var dest = new TDestination();

            var sourceProps = typeof(TSource).GetProperties();
            var destProps = typeof(TDestination).GetProperties();

            foreach (var destProp in destProps)
            {
                var sourceProp = sourceProps
                    .FirstOrDefault(p => p.Name == destProp.Name);

                if (sourceProp == null)
                    continue;

                if (!sourceProp.CanRead || !destProp.CanWrite)
                    continue;

                if (sourceProp.GetIndexParameters().Length > 0)
                    continue;

                if (!destProp.PropertyType.IsAssignableFrom(sourceProp.PropertyType))
                    continue;

                var value = sourceProp.GetValue(source);

                destProp.SetValue(dest, value);
            }

            return dest;
        }

        public static List<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> source)
            where TDestination : new()
        {
            return source
                .Select(item => Map<TSource, TDestination>(item))
                .ToList();
        }
    }
}
