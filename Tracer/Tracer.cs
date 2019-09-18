using System;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace Tracer
{
    public class Tracer
    {
        private ConcurrentDictionary<int, ConcurrentStack<Method>> _threads;
        private ConcurrentDictionary<int, ConcurrentStack<Method>> _stopThreads;
        
        public Tracer()
        {
            _threads = new ConcurrentDictionary<int, ConcurrentStack<Method>>();
            _stopThreads = new ConcurrentDictionary<int, ConcurrentStack<Method>>();
        }

        public void StartTrace()
        {
            System.Threading.Thread currentThread = System.Threading.Thread.CurrentThread;
            int threadId = currentThread.ManagedThreadId;
            ConcurrentStack<Method> stack = _threads.GetOrAdd(threadId, new ConcurrentStack<Method>());
            
            var stackTrace = new StackTrace(true);
            var stackFrames = stackTrace.GetFrames();
            var stackFrame = stackFrames[1];
            string methodName = stackFrame.GetMethod().Name;
            
            var _class = stackFrame.GetMethod().DeclaringType;
            var className = _class != null ? _class.ToString() : "";
            
            Method currMethod = new Method(methodName, className);
            stack.Push(currMethod);

            currMethod.Start();
        }

        public void StopTrace()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            System.Threading.Thread currentThread=System.Threading.Thread.CurrentThread;
            int threadId = currentThread.ManagedThreadId;
            ConcurrentStack<Method> stack;
            if (!_threads.TryGetValue(threadId, out stack))
            {
                throw new Exception("called before StartTrace");
            }
            Method currMethod;
            if (!stack.TryPop(out currMethod))
            {
                throw new Exception("called before StartTrace");
            }
            stopwatch.Stop();
            currMethod.Stop(stopwatch.ElapsedMilliseconds);
            Method parentMethod;
            if (stack.TryPeek(out parentMethod))
            {
                parentMethod.AddMethod(currMethod);
            }
            else
            {
                ConcurrentStack<Method> stopStack = _stopThreads.GetOrAdd(threadId, new ConcurrentStack<Method>());
                stopStack.Push(currMethod);
            }
        }

        public TraceResult GetTraceResult()
        {
            return new TraceResult(_stopThreads);
        }
    }
}