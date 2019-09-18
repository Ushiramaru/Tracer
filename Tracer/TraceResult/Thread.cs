namespace Tracer
{
    public class Thread
    {
        public int _id;
        public long _time;
        public Method[] _methods;

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