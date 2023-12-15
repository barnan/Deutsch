using BaseClasses;

namespace GermanDict.Interfaces
{
    public interface IRepository<T> 
    {
        IEnumerable<T> Get(string text);

        IEnumerable<T> GetAllElements();

        IEnumerable<T> Find(Predicate<T> predicate);

        void Add(T word);

        void AddRange(IEnumerable<T> words);

        void Remove(T word);

        void RemoveRange(IEnumerable<T> words);

        event EventHandler<EventArgs<string>> RepositoryChanged;


        RepositoryState GetState();

        event EventHandler<EventArgs<RepositoryState, RepositoryState>> StateChanged;
    }


    public interface IDictionaryRepository : IRepository<IDictionaryItem>
    {
        IEnumerable<IArticle> GetArticles(Language language);

        IEnumerable<IWordAttribute> GetAllWordAttributes();

        void AddWordAttrbibute(IWordAttribute wordAttrbibute);

        void AddArticle(IArticle article);
    }

}
