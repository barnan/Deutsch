
namespace GermanDict.Interfaces
{
    public interface IDictionaryItemPair
    {
        IDictionaryItem Item1 { get; }
        IDictionaryItem Item2 { get; }
    }


    public interface IDictionaryItemConnection : IFormattable
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
