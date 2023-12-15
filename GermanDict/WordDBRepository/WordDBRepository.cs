using GermanDict.Interfaces;
using BaseClasses;

namespace GermanDict.WordDBRepository
{
    public class WordDBRepository<T> : IRepository<T>
        where T : IRepositoryElement
    {
        
        #region IRepository<IWord>

        public void Add(T word)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<T> words)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get(string text)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllElements()
        {
            throw new NotImplementedException();
        }

        public void Remove(T word)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> words)
        {
            throw new NotImplementedException();
        }

        public RepositoryState GetState()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<EventArgs<string>> RepositoryChanged;
        public event EventHandler<EventArgs<RepositoryState, RepositoryState>> StateChanged;

        #endregion
    }
}