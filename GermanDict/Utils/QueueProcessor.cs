namespace Utils
{
    public class QueueProcessor<T>
    {
        private int _capacity;
        private Queue<T> _internalQueue;
        private Action<T> _actionToDo;
        private object _lockObject;
        private Thread _processorThread;
        private CancellationTokenSource _tokenSource;
        
        #region public

        public QueueProcessor(Action<T> actionToDo, int maxQueueCapacity)
        {
            if (maxQueueCapacity < 1)
            {
                // log error
            }

            _capacity = maxQueueCapacity;
            _lockObject = new object();
            _actionToDo = actionToDo;
            _internalQueue = new Queue<T>(maxQueueCapacity);

            // in init??
            _tokenSource = new CancellationTokenSource();
            _processorThread = new Thread(Processor)
            {
                IsBackground = true,
                Name = "QueueProcessor Thread"
            };
            _processorThread.Start(_tokenSource.Token);

            //log
        }

        public bool EnqueueNewElement(T newElement)
        {
            lock(_lockObject)
            {
                if (_internalQueue.Count == _capacity -1)
                {
                    //log
                    return false;
                }

                _internalQueue.Enqueue(newElement);
                return true;
            }
        }

        public void ClearQueue()
        { 
            //log
            lock(_lockObject)
            {
                _internalQueue.Clear();
            }
        }

        #endregion
        
        #region private

        private void Processor(object obj)
        {



            // log action starts

            _actionToDo(obj);

            // log action ends
        } 
        #endregion
    }
}