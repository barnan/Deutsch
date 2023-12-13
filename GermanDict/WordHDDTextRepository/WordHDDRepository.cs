using GermanDict.Interfaces;
using GermanDict.WordHDDTextRepository.FileHandlers;
using GermanDict.WordHDDTextRepository.Collection;
using Interfaces;

namespace GermanDict.WordHDDTextRepository
{
    public class WordHDDRepository<T> : IRepository<T>, Interfaces.IObserver<RepositoryState>
        where T : IRepositoryElement
    {
        #region consts

        private const string _HDD_FOLDER_PATH_SUPPLEMENT = "WordHDDTextRepository";
        private const int _MAINTENANCE_CYCLE_TIME_MS = 10000;

        #endregion consts

        #region private fields

        private MyCollection<T> _set;
        private string _folderFullPath;
        private string _fileFullPath;
        private Thread _maintenanceThread;
        private CancellationTokenSource _cts;

        private IDictionaryItemParser<T> _parser;
        private IRepositoryTextFileHandler _fileHandler;

        private object _lockObj;

        #endregion private fields

        public WordHDDRepository(string externalPath, string fileName, IDictionaryItemParser<T> parser)
        {
            _lockObj = new object();

            _folderFullPath = Path.Combine(externalPath, _HDD_FOLDER_PATH_SUPPLEMENT);
            _fileFullPath = Path.Combine(_folderFullPath, fileName);

            if (!Directory.Exists(_folderFullPath))
            {
                Directory.CreateDirectory(_folderFullPath);
            }

            _set = new MyCollection<T>();
            _parser = parser;
            _fileHandler = new RepositoryTextFileHandler(_fileFullPath);

            _cts = new CancellationTokenSource();
            _maintenanceThread = new Thread(Maintenance)
            {
                IsBackground = true,
                Name = $"{nameof(WordHDDRepository<T>)}_Maintenance_Thread"
            };
            _maintenanceThread.Start(_cts.Token);

            try
            {
                IEnumerable<string> fileContent = _fileHandler.GetContent();
                IEnumerable<T> ts = fileContent.Select(a => _parser.Parse(a));
                AddRange(ts);
            }
            catch (Exception ex)
            {
                // do something!!!
                // logging or something
            }
        }

        #region IRepository<IWord>

        public void Add(T itemToAdd)
        {
            lock (_lockObj)
            {
                if (_set.Contains(itemToAdd))
                {
                    return;
                }
                _set.Add(itemToAdd);
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            lock (_lockObj)
            {
                foreach (T item in items)
                {
                    Add(item);
                }
            }
        }

        public IEnumerable<T> Find(Predicate<T> predicate)
        {
            lock (_lockObj)
            {
                return _set.Find(predicate);
            }
        }

        public IEnumerable<T> Get(string text)
        {
            lock (_lockObj)
            {
                List<T> results = new List<T>();
                if (string.IsNullOrEmpty(text))
                {
                    return results;
                }

                results.AddRange(Find(delegate (T item)
                {
                    return (item as IRepositoryElement).IsMatchingWithText(text);
                }));

                return results;
            }
        }

        public IEnumerable<T> GetAllElements()
        {
            lock (_lockObj)
            {
                List<T> results = new List<T>();

                Predicate<T> pred = delegate (T item) { return true; };
                results.AddRange(Find(pred));

                return results;
            }
        }

        public void Remove(T itemToRemove)
        {
            lock (_lockObj)
            {
                _set.Remove(itemToRemove);
            }
        }

        public void RemoveRange(IEnumerable<T> itemsToRemove)
        {
            lock (_lockObj)
            {
                foreach (var item in itemsToRemove)
                {
                    Remove(item);
                }
            }
        }

        #endregion IRepository<IWord>

        #region Maintenance

        private void Maintenance(object obj)
        {
            if (obj is not CancellationToken token)
            {
                throw new ArgumentException("Not proper parameter");
            }

            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }
                if (_set.IsUpdated)
                {
                    DoMaintenanceInternal();
                }
                Thread.Sleep(_MAINTENANCE_CYCLE_TIME_MS);
            }
        }

        private void DoMaintenanceInternal()
        {
            try
            {
                List<string> allWordsText = new List<string>();
                allWordsText.AddRange(_set.Select(_parser.Convert));
                _fileHandler.SaveContent(allWordsText);
            }
            catch (Exception ex)
            {
                // do something!!!
                // logging or something
            }
        }

        #endregion Maintenance

        #region IObserver<T>

        public RepositoryState GetState()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<EventArgs<RepositoryState, RepositoryState>> StateChanged;

        protected void OnStateChanged(RepositoryState oldState, RepositoryState newState)
        {
            EventArgs<RepositoryState, RepositoryState> repoStateArgs = new EventArgs<RepositoryState, RepositoryState>(oldState, newState);
            var stateChanged = StateChanged;

            stateChanged(this, repoStateArgs);
        }

        #endregion
    }
}