
namespace GermanDict.Interfaces
{
    public interface IDictionaryParser<T>
    {
        T Parse(string text);

        string Convert(T word);
    }
}
