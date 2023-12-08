
namespace GermanDict.Interfaces
{
    public interface IDictionaryItemConnection
    {
        IDictionaryItemPair DictionaryItemPair { get; }

    }


    public interface IWordMeaning : IDictionaryItemConnection
    {
        
    }


    public interface IPhraseContains : IDictionaryItemConnection
    {

    }


}
