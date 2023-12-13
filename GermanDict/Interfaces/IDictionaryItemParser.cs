
namespace GermanDict.Interfaces
{
    public interface IDictionaryItemParser<T>
    {
        T Parse(string text);

        string Convert(T word);
    }
}
