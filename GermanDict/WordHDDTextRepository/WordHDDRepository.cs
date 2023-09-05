using GermanDict.Interfaces;
using GermanDict.WordHDDTextRepository.FileHandlers;
using GermanDict.WordHDDTextRepository.Parsers;

namespace GermanDict.WordHDDTextRepository
{
    public class WordHDDRepository : IRepository<IWord>
    {
        #region consts

        private const string _HDD_FOLDER_PATH_SUPPLEMENT = "WordHDDTextRepositry";
        private const string _HDD_VERB_FILE_NAME = "Verbs.dict";
        private const string _HDD_ADJECTIVE_FILE_NAME = "Adjectives.dict";
        private const string _HDD_NOUN_FILE_NAME = "Nouns.dict";
        //private const int _MAINTENANCE_CYCLE_TIME_MS = 10000;

        #endregion

        #region private fields

        private HashSet<INoun> _nounSet;
        private HashSet<IVerb> _verbSet;
        private HashSet<IAdjective> _adjectiveSet;

        private string _folderFullPath; 
        private string _nounFileFullPath; 
        private string _verbFileFullPath; 
        private string _adjectiveFileFullPath;
        private Thread _maintenanceThread;
        private CancellationTokenSource _cts;

        private IWordParser _nounParser;
        private IWordParser _verbParser;
        private IWordParser _adjParser;
        private IRepositoryTextFileHandler _fileHandler;

        private object _lockObj;
        //private object _maintenanceLockObject;

        #endregion

        public WordHDDRepository(string externalPath)
        {
            _lockObj = new object();
            //_maintenanceLockObject = new object();

            _folderFullPath = Path.Combine(externalPath, _HDD_FOLDER_PATH_SUPPLEMENT);
            _nounFileFullPath = Path.Combine(_folderFullPath, _HDD_NOUN_FILE_NAME);
            _verbFileFullPath = Path.Combine(_folderFullPath, _HDD_VERB_FILE_NAME);
            _adjectiveFileFullPath = Path.Combine(_folderFullPath, _HDD_ADJECTIVE_FILE_NAME);

            if (!Directory.Exists(_folderFullPath))
            {
                Directory.CreateDirectory(_folderFullPath);
            }

            _nounParser = new NounParser();
            _verbParser = new VerbParser();
            _adjParser = new AdjectiveParser();

            _fileHandler = new RepositoryTextFileHandler(_nounFileFullPath, _verbFileFullPath, _adjectiveFileFullPath);

            //_cts = new CancellationTokenSource();
            //_maintenanceThread = new Thread(Maintenance)
            //{
            //    IsBackground = true,
            //    Name = $"{nameof(WordHDDRepository)}_Maintenance_Thread"
            //};
            //_maintenanceThread.Start(_cts.Token);
        }

        #region IRepository<IWord>

        public void Add(IWord word)
        {
            lock(_lockObj)
            {
                IWordParser parser = GetProperParser(word);
                string wordText = parser.Convert(word);
                _fileHandler.SaveLine(wordText, word.WordType);
            }
        }

        public void AddRange(IEnumerable<IWord> items)
        {
            lock (_lockObj)
            {
                foreach (IWord word in items)
                {
                    Add(word);
                } 
            }
        }

        public IEnumerable<IWord> Find(Predicate<IWord> predicate)
        {
            throw new NotFiniteNumberException();
        }

        //public IWord Get(int index)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<IWord> Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                //log
                return null;
            }

            lock(_lockObj)
            {
                using(StreamReader sr = new StreamReader())
                { }
            }
        }

        public IEnumerable<IWord> GetAllElements()
        {
            lock (_lockObj)
            {
                
            }
        }

        public void Remove(IWord word)
        {
            var wordTexts = _fileHandler.GetLines(word.WordType);
            IWordParser parser = GetProperParser(word);
            List<IWord> words = new List<IWord>();

            foreach (var itemText in wordTexts)
            {
                words.Add(parser.Parse(itemText));
            }
            words.
            
        }

        public void RemoveRange(IEnumerable<IWord> items)
        {
            throw new NotImplementedException();
        }

        #endregion

        //#region Maintenance

        //private void Maintenance(object obj)
        //{
        //    if (obj is not CancellationToken token)
        //    {
        //        // do something!!
        //        return;
        //    }

        //    while(true)
        //    {
        //        if (token.IsCancellationRequested)
        //        {
        //            break;
        //        }

        //        DoMaintenanceInternal();

        //        Thread.Sleep(_MAINTENANCE_CYCLE_TIME_MS);
        //    }
        //}

        //private void DoMaintenanceInternal()
        //{

        //}

        //#endregion


        #region private

        private IWordParser GetProperParser(IWord word)
        {
            switch (word.WordType)
            {
                case WordType.Noun:
                    return _nounParser;
                case WordType.Verb:
                    return _verbParser;
                case WordType.Adjective:
                    return _adjParser;
                default:
                    throw new ArgumentException($"The word contains an unhandled {nameof(WordType)} -> \"{word.WordType}\"");
            }
        }

        #endregion
    }
}