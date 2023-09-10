
using GermanDict.Interfaces;
using GermanDict.WordHDDTextRepository;

namespace Factories
{
    public class RepositoryFactory<T>
        where T : IRepositoryElement
    {

        public IRepository<T> CreateRepository(string externalPath, string fileName, IParser<T> parser)
        {
            //if (parser is IParser<IWord> wordParser)
                return new WordHDDRepository(externalPath, fileName, parser);
            
        }
    }
}
