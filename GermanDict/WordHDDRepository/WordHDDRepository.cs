using GermanDict.Interfaces;

namespace GermanDict.WordHDDRepository
{
    public class WordHDDRepository : IRepository<IWord>
    {

        #region IRepository<IWord>

        public bool Add(IWord item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<IWord> items)
        {
            throw new NotImplementedException();
        }

        public List<IWord> Find(Predicate<IWord> predicate)
        {
            throw new NotImplementedException();
        }

        public IWord Get(int index, IComparer<IWord> comparer = null)
        {
            throw new NotImplementedException();
        }

        public IWord Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<IWord> GetAllElements()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IWord item)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<IWord> items)
        {
            throw new NotImplementedException();
        }

        public bool SetFolder(string path)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}