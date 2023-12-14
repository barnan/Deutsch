
namespace Interfaces
{
    public class EventArgs<T1> : EventArgs
    {
        public T1 Argument { get; }

        public EventArgs(T1 argument)
        {
            Argument = argument;
        }
    }

    public class EventArgs<T1, T2> : EventArgs
    {
        public T1 Argument1 { get; }
        public T2 Argument2 { get; }

        public EventArgs(T1 argument1, T2 argument2)
        {
            Argument1 = argument1;
            Argument2 = argument2;
        }
    }


    /// <summary>
    /// copied from: https://www.codeproject.com/Articles/5341837/Asynchronous-Events-in-Csharp 
    /// and I've commented some line of it.
    /// </summary>
    public static class AsyncEventsUsingTplExtension
    {
        public static void InvokeAsync<TEventArgs>(this EventHandler<TEventArgs> handler, object sender, TEventArgs args)
        {
            //Task.Factory.StartNew(() =>
            //{
                //Console.WriteLine("InvokeAsync<TEventArgs> is running on ThreadId:{0}",
                //    Thread.CurrentThread.ManagedThreadId);

                var delegates = handler?.GetInvocationList();

                foreach (var delegated in delegates)
                {
                    var myEventHandler = delegated as EventHandler<TEventArgs>;
                    if (myEventHandler != null)
                    {
                        Task.Factory.StartNew(() => myEventHandler(sender, args));
                    }
                };
            //});
        }
    }

}
