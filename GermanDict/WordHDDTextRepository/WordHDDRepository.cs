using GermanDict.Interfaces;

namespace GermanDict.WordHDDTextRepository
{
    public class WordHDDRepository : IRepository<IWord>
    {
        #region consts

        private const string _HDD_FOLDER_PATH_SUPPLEMENT = "WordHDDTextRepositry";
        private const string _HDD_VERB_FILE_NAME = "Verbs.dict";
        private const string _HDD_ADJECTIVE_FILE_NAME = "Adjectives.dict";
        private const string _HDD_NOUN_FILE_NAME = "Nouns.dict";
        private const int _MAINTENANCE_CYCLE_TIME_MS = 10000;

        #endregion
        
        private string _folderFullPath; 
        private string _nounFileFullPath; 
        private string _verbFileFullPath; 
        private string _adjectiveFileFullPath;
        private Thread _maintenanceThread;
        private CancellationTokenSource _cts;

        private List<INoun> _nounCache;
        private List<IVerb> _verbCache;
        private List<IAdjective> _adjCache;

        public WordHDDRepository(string externalPath)
        {
            _folderFullPath = Path.Combine(externalPath, _HDD_FOLDER_PATH_SUPPLEMENT);
            _nounFileFullPath = Path.Combine(_folderFullPath, _HDD_NOUN_FILE_NAME);
            _verbFileFullPath = Path.Combine(_folderFullPath, _HDD_VERB_FILE_NAME);
            _adjectiveFileFullPath = Path.Combine(_folderFullPath, _HDD_ADJECTIVE_FILE_NAME);

            _nounCache = new List<INoun>();
            _verbCache = new List<IVerb>();
            _adjCache = new List<IAdjective>();

            if (!Directory.Exists(_folderFullPath))
            {
                Directory.CreateDirectory(_folderFullPath);
            }

            _cts = new CancellationTokenSource();
            _maintenanceThread = new Thread(Maintenance)
            {
                IsBackground = true,
                Name = $"{nameof(WordHDDRepository)}_Maintenance_Thread"
            };
            _maintenanceThread.Start(_cts.Token);
        }

        #region IRepository<IWord>

        public bool Add(IWord item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<IWord> items)
        {
            throw new NotImplementedException();
        }

        public List<IWord> Find(Predicate<IWord> predicate)
        {
            throw new NotImplementedException();
        }

        public IWord Get(int index, IComparer<IWord> comparer = null)
        {
            throw new NotImplementedException();
        }

        public IWord Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<IWord> GetAllElements()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IWord item)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<IWord> items)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Maintenance

        private void Maintenance(object obj)
        {
            if (obj is not CancellationToken token)
            {
                // do something!!
                return;
            }
 
            while(true)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                DoMaintenanceInternal();

                Thread.Sleep(_MAINTENANCE_CYCLE_TIME_MS);
            }
        }

        private void DoMaintenanceInternal()
        {

        }

        #endregion
    }
}