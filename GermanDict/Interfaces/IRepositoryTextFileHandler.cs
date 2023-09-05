
namespace GermanDict.Interfaces
{
    public interface IRepositoryTextFileHandler
    {
        void SaveLine(string text, WordType wordType);

        IEnumerable<string> GetLines(WordType wordType);
    }
}
