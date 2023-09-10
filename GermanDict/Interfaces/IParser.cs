
namespace GermanDict.Interfaces
{
    public interface IParser<T>
    {
        T Parse(string text);

        string Convert(T word);
    }
}
