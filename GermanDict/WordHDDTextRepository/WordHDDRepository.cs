using GermanDict.Interfaces;
using GermanDict.WordHDDTextRepository.FileHandlers;
using GermanDict.WordHDDTextRepository.Collection;

namespace GermanDict.WordHDDTextRepository
{
    public class WordHDDRepository<T> : IRepository<T>
        where T : IRepositoryElement
    {
        #region consts

        private const string _HDD_FOLDER_PATH_SUPPLEMENT = "WordHDDTextRepositry";
        private const int _MAINTENANCE_CYCLE_TIME_MS = 10000;

        #endregion

        #region private fields

        private MyCollection<T> _set;
        private string _folderFullPath; 
        private string _fileFullPath; 
        private Thread _maintenanceThread;
        private CancellationTokenSource _cts;

        private IParser<T> _parser;
        private IRepositoryTextFileHandler _fileHandler;

        private object _lockObj;

        #endregion

        public WordHDDRepository(string externalPath, string fileName, IParser<T> parser)
        {
            _lockObj = new object();

            _folderFullPath = Path.Combine(externalPath, _HDD_FOLDER_PATH_SUPPLEMENT);
            _fileFullPath = Path.Combine(_folderFullPath, fileName);

            if (!Directory.Exists(_folderFullPath))
            {
                Directory.CreateDirectory(_folderFullPath);
            }

            _parser = parser;
            _fileHandler = new RepositoryTextFileHandler(_fileFullPath);

            _cts = new CancellationTokenSource();
            _maintenanceThread = new Thread(Maintenance)
            {
                IsBackground = true,
                Name = $"{nameof(WordHDDRepository<T>)}_Maintenance_Thread"
            };
            _maintenanceThread.Start(_cts.Token);
        }        

        #region IRepository<IWord>

        public void Add(T itemToAdd)
        {
            lock(_lockObj)
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
            lock(_lockObj)
            {
                List<T> results = new List<T>();
                foreach (var item in _set)
                {
                    if (predicate.Invoke(item))
                    {
                        results.Add(item);
                    }
                }
                return results;
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
            lock(_lockObj)
            {
                foreach (var item in itemsToRemove)
                {
                    Remove(item);
                }
            }
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
            }
        }

        #endregion
    }
}