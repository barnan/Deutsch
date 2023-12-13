
namespace GermanDict.Interfaces
{

    public enum WordType
    {
        Article,
        Attribute,
        Phrase,
        Noun,
        Verb,
        Adjective        
    }


    public enum Language
    {
        Unknown,
        Hungarian,
        German,
        English,
    }


    public enum AdjectiveBoosting
    {
        Normal,
        Unusual
    }

    public enum RepositoryState
    {
        Idle,
        Busy
    }

}
