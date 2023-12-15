using GermanDict.Interfaces;

namespace GermanDict.DateTimeProvider
{
    public class WordFactory : IFactory
    {
        public static IDateTimeProvider CreateDateTimeProvider()
        {
            return new DefaultDateTimeProvider();
        }
    }

}
