﻿namespace Tracer
{
    public class Thread
    {
        private long _time;
        private Method[] _methods;
        private int _id;
        
        public int Id => _id;
        public long Time => _time;
        public Method[] Methods => _methods;
        
        public Thread(int id, Method[] methods)
        {
            _id = id;
            _time = 0;
            _methods = methods;
            for (int i = 0; i < _methods.Length; i++)
            {
                _time += methods[i].Time;
            }
        }
    }
}