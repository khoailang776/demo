using AutoMapper;

namespace DemoClass.Config
{
    public static class MapperEx
    {
        public static T Map<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }
    }
}
