
namespace GermanDict.Interfaces
{
    public interface IRepositoryTextFileHandler
    {
        void SaveContent(IEnumerable<string> content);

        IEnumerable<string> GetContent();
    }
}
