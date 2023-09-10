using GermanDict.Interfaces;

namespace GermanDict.WordDBRepository
{
    public class WordDBRepository : IRepository<IWord>
    {

        #region IRepository<IWord>

        public void Add(IWord word)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<IWord> words)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IWord> Find(Predicate<IWord> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IWord> Get(string text)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IWord> GetAllElements()
        {
            throw new NotImplementedException();
        }

        public void Remove(IWord word)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<IWord> words)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}