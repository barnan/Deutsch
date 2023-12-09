
using System.Collections;

namespace GermanDict.WordHDDTextRepository.Collection
{
    internal class MyCollection<T> : ICollection<T>
    {
        private ReaderWriterLockSlim _rwls = new ReaderWriterLockSlim();
        private HashSet<T> _set = new HashSet<T>();
        private bool _updated = false;

        #region ICollection<T>

        public void Add(T newItem)
        {
            _rwls.EnterWriteLock();
            try
            {
                _set.Add(newItem);
                _updated = true;
            }
            finally
            {
                _rwls.ExitWriteLock();
            }
        }

        public void Clear()
        {
            _rwls.EnterWriteLock();
            try
            {
                _set.Clear();
                _updated = true;
            }
            finally
            {
                _rwls.ExitWriteLock();
            }
        }

        public bool Contains(T itemToCheck)
        {
            _rwls.EnterReadLock();
            try
            {
                return _set.Contains(itemToCheck);
            }
            finally
            {
                _rwls.ExitReadLock();
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T itemToRemove)
        {
            _rwls.EnterWriteLock();
            try
            {
                _set.Remove(itemToRemove);
                _updated = true;
                return true;
            }
            finally
            {
                _rwls.ExitWriteLock();
            }
        }

        public int Count
        {
            get
            {
                _rwls.EnterReadLock();
                try
                {
                    return _set.Count;
                }
                finally
                {
                    _rwls.ExitReadLock();
                }
            }
        }

        public bool IsReadOnly => false;

        public IEnumerator<T> GetEnumerator()
        {
            return (_set as IEnumerable<T>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        #endregion

        internal bool IsUpdated 
        { 
            get
            {
                _rwls.EnterReadLock();
                try
                {
                    return _updated;
                }
                finally
                {
                    _rwls.ExitReadLock();
                }
            }
        } 
            
        internal void ResetUpdated()
        {
            _rwls.EnterWriteLock();
            try
            {
                _updated = false;
            }
            finally
            {
                _rwls.ExitWriteLock();
            }
        }

        internal void Reset()
        {
            _rwls.EnterWriteLock();
            try
            {
                Clear();
                ResetUpdated();
            }
            finally
            {
                _rwls.ExitWriteLock();
            }
        }

        internal IEnumerable<T> Find(Predicate<T> predicate)
        {
            _rwls.EnterReadLock();
            try
            {
                Func<T, bool> func = new Func<T, bool>(predicate);
                return _set.Where(func);
            }
            finally
            {
                _rwls.ExitReadLock();
            }
        }

    }
}
