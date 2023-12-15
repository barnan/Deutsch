using GermanDict.Interfaces;

namespace GermanDict.DateTimeProvider
{
    internal class DefaultDateTimeProvider : IDateTimeProvider, IDisposable
    {
        private readonly List<IObserver<DateTime>> _observers = new List<IObserver<DateTime>>();
        

        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }

        public IDisposable Subscribe(IObserver<DateTime> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        #region IDisposable

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void EndTransmission()
        {
            foreach (var observer in _observers)
            {
                if (_observers.Contains(observer))
                {
                    observer.OnCompleted();
                }
            }      
            _observers.Clear();
        }

        #endregion
    }


    internal class Unsubscriber : IDisposable
    {
        private List<IObserver<DateTime>> Observers { get; }
        private IObserver<DateTime> Observer { get; }

        public Unsubscriber(List<IObserver<DateTime>> observers, IObserver<DateTime> observer)
        {
            Observer = observer;
            Observers = observers;
        }


        public void Dispose()
        {
            if (Observer != null && Observers.Contains(Observer))
            {
                Observers.Remove(Observer);
            }
                
        }
    }

}