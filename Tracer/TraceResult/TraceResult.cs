using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Tracer
{
    public class TraceResult
    {
        private Thread[] _threads;

        public Thread[] Threads
        {
            get => _threads;
            set => _threads = value;
        }

        public TraceResult()
        {
        }

        public TraceResult(ConcurrentDictionary<int, ConcurrentStack<Method>> threads)
        {
            KeyValuePair<int, ConcurrentStack<Method>>[] pairs = threads.ToArray();
            _threads = new Thread[pairs.Length];
            for (int i = 0; i < pairs.Length; i++)
            {
                var stack = pairs[i].Value;
                Method[] methods = stack.ToArray();
                _threads[i] = new Thread(pairs[i].Key, methods);
            }
        }

//        public Thread[] Threads => _threads;
        
//        public Thread[] Threads

    }
}