using GermanDict.Interfaces;
using GermanDict.HDDTextRepository.FileHandlers;
using GermanDict.HDDTextRepository.Collection;
using System.Data;
using BaseClasses;

namespace GermanDict.HDDTextRepository
{
    public class HDDRepository<T> : IRepository<T>
        where T : IRepositoryElement
    {
        #region consts

        private const string _HDD_FOLDER_PATH_SUPPLEMENT = "WordHDDTextRepository";
        private const int _MAINTENANCE_CYCLE_TIME_MS = 10000;

        #endregion consts

        #region private fields

        protected MyCollection<T> _set;
        private string _folderFullPath;
        private string _fileFullPath;
        private Thread _maintenanceThread;
        private CancellationTokenSource _cts;

        protected IItemParser<T> _parser;
        protected IRepositoryTextFileHandler _fileHandler;

        protected object _repositoryLock;
        ReaderWriterLockSlim _stateLock;

        #endregion private fields

        #region ctor

        public HDDRepository(string externalPath, string fileName, IItemParser<T> parser)
        {
            _repositoryLock = new object();
            _stateLock = new ReaderWriterLockSlim();

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
                Name = $"{nameof(HDDRepository<T>)}_Maintenance_Thread"
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

        #endregion

        #region IRepository<T>

        public virtual void Add(T itemToAdd)
        {
            lock (_repositoryLock)
            {
                if (_set.Contains(itemToAdd))
                {
                    return;
                }
                _set.Add(itemToAdd);
            }
        }

        public virtual void AddRange(IEnumerable<T> items)
        {
            lock (_repositoryLock)
            {
                foreach (T item in items)
                {
                    Add(item);
                }
            }
        }

        public virtual IEnumerable<T> Find(Predicate<T> predicate)
        {
            lock (_repositoryLock)
            {
                return _set.Find(predicate);
            }
        }

        public virtual IEnumerable<T> Get(string text)
        {
            lock (_repositoryLock)
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

        public virtual IEnumerable<T> GetAllElements()
        {
            lock (_repositoryLock)
            {
                List<T> results = new List<T>();

                Predicate<T> pred = delegate (T item) { return true; };
                results.AddRange(Find(pred));

                return results;
            }
        }

        public virtual void Remove(T itemToRemove)
        {
            lock (_repositoryLock)
            {
                _set.Remove(itemToRemove);
            }
        }

        public virtual void RemoveRange(IEnumerable<T> itemsToRemove)
        {
            lock (_repositoryLock)
            {
                foreach (var item in itemsToRemove)
                {
                    Remove(item);
                }
            }
        }

        public event EventHandler<EventArgs<string>> RepositoryChanged;
        RepositoryState _state;

        protected void OnRepositoryChanged(string text)
        {
            var textArgs = new EventArgs<string>(text);
            RepositoryChanged.InvokeAsync<EventArgs<string>>(this, textArgs);
        }
                
        protected virtual void SetState(RepositoryState newState)
        {
            _stateLock.EnterWriteLock();
            try
            {
                RepositoryState oldState = _state;
                _state = newState;
                OnStateChanged(oldState, _state);
            }
            finally
            {
                _stateLock.ExitWriteLock();
            }
        }

        public virtual RepositoryState GetState()
        {
            _stateLock.EnterReadLock();
            try
            {
                return _state;
            }
            finally
            {
                _stateLock.ExitReadLock();
            }
        }

        public event EventHandler<EventArgs<RepositoryState, RepositoryState>> StateChanged;

        protected void OnStateChanged(RepositoryState oldState, RepositoryState newState)
        {
            var stateArgs = new EventArgs<RepositoryState, RepositoryState>(oldState, newState);

            StateChanged.InvokeAsync<EventArgs<RepositoryState, RepositoryState>>(this, stateArgs);
        }

        #endregion IRepository<T>

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

        protected virtual void DoMaintenanceInternal()
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

        #endregion Maintenance
        
    }
}