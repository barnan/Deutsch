
namespace GermanDict.Interfaces
{

    public interface IDictionaryItem : IFormattable, IEquatable<IDictionaryItem>, IRepositoryElement
    {
    }


    public interface ILanguageDictionaryItem : IDictionaryItem
    {
        Language Language { get; }
    }


    public interface IPhrase : ILanguageDictionaryItem
    {
        string Text { get; }
        bool Contains(IWord word);
    }


    public interface IWordAttribute : IDictionaryItem
    {
        public string Text { get; }
    }


    public interface IArticle : ILanguageDictionaryItem
    {
        string Name { get; }
    }
}
