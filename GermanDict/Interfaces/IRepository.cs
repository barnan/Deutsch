
using Interfaces;

namespace GermanDict.Interfaces
{
    public interface IRepository<T> 
    {
        //T Get(int index);

        IEnumerable<T> Get(string text);

        IEnumerable<T> GetAllElements();

        IEnumerable<T> Find(Predicate<T> predicate);

        void Add(T word);

        void AddRange(IEnumerable<T> words);

        void Remove(T word);

        void RemoveRange(IEnumerable<T> words);
    }

    public interface IObserver<T>
    {
        T GetState();

        event EventHandler<EventArgs<T, T>> StateChanged;
    }
        
}
