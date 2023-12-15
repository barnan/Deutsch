
using GermanDict.Interfaces;
using GermanDict.HDDTextRepository;

namespace Factories
{
    public class RepositoryFactory<T> : IFactory
        where T : IRepositoryElement
    {

        public static IRepository<T> CreateRepository(string externalPath, string fileName, IItemParser<T> parser)
        {
            //if (parser is IParser<IWord> wordParser)
            return new HDDRepository<T>(externalPath, fileName, parser);

        }

        //public IRepository<G> CreateRepository<G>(string externalPath, string fileName, IParser<G> parser)
        //{
        //    var mi = typeof(WordHDDRepository).GetMethod("Foo");
        //    var fooRef = mi.MakeGenericMethod(bar);
        //    fooRef.Invoke(new Test(), null);


        //    //if (parser is IParser<IWord> wordParser)
        //    return new WordHDDRepository<G>(externalPath, fileName, parser);

        //}

    }
}
