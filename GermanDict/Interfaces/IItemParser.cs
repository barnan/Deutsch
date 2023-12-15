
namespace GermanDict.Interfaces
{
    public interface IItemParser<T>
    {
        T Parse(string text);

        string Convert(T word);
    }
}
