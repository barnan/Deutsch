﻿
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

}
