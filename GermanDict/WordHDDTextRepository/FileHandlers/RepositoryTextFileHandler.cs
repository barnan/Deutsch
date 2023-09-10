using GermanDict.Interfaces;
using System.Text;

namespace GermanDict.WordHDDTextRepository.FileHandlers
{
    internal class RepositoryTextFileHandler : IRepositoryTextFileHandler
    {
        private string _filePath;
        public RepositoryTextFileHandler(string filePath)
        {
            _filePath = filePath;
        }

        #region IRepositoryTextFileHandler

        public IEnumerable<string> GetContent()
        {
            string[] lines = File.ReadAllLines(_filePath, Encoding.UTF8);
            return lines;
        }

        public void SaveContent(IEnumerable<string> content)
        {
            File.Delete(_filePath);
            File.AppendAllLines(_filePath, content);
        }

        #endregion
    }
}
