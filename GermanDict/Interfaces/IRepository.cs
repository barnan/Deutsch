
namespace GermanDict.Interfaces
{
    public interface IRepository<T> 
    {
        T Get(int index);

        List<T> Get(string text);

        List<T> GetAllElements();

        List<T> Find(Predicate<T> predicate);

        bool Add(T item);

        void AddRange(IEnumerable<T> items);

        bool Remove(T item);

        void RemoveRange(IEnumerable<T> items);
    }
}
