using GermanDict.HDDTextRepository;
using GermanDict.Interfaces;

namespace GermanDict.DictionaryRepository
{
    internal class DictionaryRepository : HDDRepository<IDictionaryItem>, IDictionaryRepository
    {
        internal DictionaryRepository(string externalPath, string fileName, IItemParser<IDictionaryItem> parser) 
            : base(externalPath, fileName, parser)
        {
        }

        #region IDictionaryRepository

        public void AddArticle(IArticle article)
        {
            throw new NotImplementedException();
        }

        public void AddWordAttrbibute(IWordAttribute wordAttrbibute)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IWordAttribute> GetAllWordAttributes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IArticle> GetArticles(Language language)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region override IDictionary<T>

        protected override void DoMaintenanceInternal()
        {
            try
            {
                SetState(RepositoryState.Busy);

                List<string> allWordsText = new List<string>();
                allWordsText.AddRange(_set.Select(_parser.Convert));
                _fileHandler.SaveContent(allWordsText);

                SetState(RepositoryState.Idle);
            }
            catch (Exception ex)
            {
                // do something!!!
                // logging or something
            }
        }


        #endregion
    }
}