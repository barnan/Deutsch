
namespace GermanDict.Interfaces
{
    public interface IWordParser
    {
        IWord Parse(string text);

        string Convert(IWord word);
    }
}
