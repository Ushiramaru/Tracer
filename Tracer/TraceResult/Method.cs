using System;
using System.Diagnostics;

namespace Tracer
{
    public class Method
    {
        private string _name;
        private string _className;
        private long _time;
        private Method[] _methods;
        private Stopwatch _stopwatch;

        public Method(string name, string className)
        {
            _name = name;
            _className = className;
            _time = 0;
            _methods = null;
            _stopwatch = new Stopwatch();
        }

        public long Time
        {
            get => _time;
            set => _time = value;
        }

        public void Start()
        {
            _stopwatch.Start();
        }

        public void Stop(long time)
        {
            _stopwatch.Stop();
            _time = _stopwatch.ElapsedMilliseconds - time;
        }

        public void AddMethod(Method method)
        {
            Array.Resize(ref _methods, _methods.Length+1);
            _methods[_methods.Length - 1] = method;
        }
    }
}