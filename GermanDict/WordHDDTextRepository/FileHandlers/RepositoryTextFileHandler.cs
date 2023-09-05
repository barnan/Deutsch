
using GermanDict.Interfaces;
using System.Text;

namespace GermanDict.WordHDDTextRepository.FileHandlers
{
    internal class RepositoryTextFileHandler : IRepositoryTextFileHandler
    {
        private string _nounFilePath;
        private string _verbFilePath;
        private string _adjFilePath;

        public RepositoryTextFileHandler(string nounFilePath, string verbFilePath, string adjFilePath)
        {
            _nounFilePath = nounFilePath;
            _verbFilePath = verbFilePath;
            _adjFilePath = adjFilePath;
        }

        #region IRepositoryTextFileHandler

        public IEnumerable<string> GetLines(WordType wordType)
        {
            string filePath = GetFilePathFerWordType(wordType);
            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
            return lines;
        }

        public void SaveLine(string text, WordType wordType)
        {
            string filePath = GetFilePathFerWordType(wordType);
            File.AppendAllLines(filePath, new[] { text });
        }

        #endregion

        #region private

        private string GetFilePathFerWordType (WordType wordType)
        {
            string filePath;
            switch (wordType)
            {
                case WordType.Noun:
                    filePath = _nounFilePath;
                    break;
                case WordType.Verb:
                    filePath = _verbFilePath;
                    break;
                case WordType.Adjective:
                    filePath = _adjFilePath;
                    break;
                default:
                    throw new ArgumentException($"The word contains an unhandled {nameof(WordType)} -> \"{wordType}\"");
            }
            return filePath;
        }

        #endregion

    }
}
