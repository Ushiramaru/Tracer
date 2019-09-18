using System.Threading;

namespace ConsoleApp.FakeClass
{
    public class Class1
    {
        private Tracer.Tracer _tracer;

        public Class1(Tracer.Tracer tracer)
        {
            _tracer = tracer;
        }
        public void f1()
        {
            _tracer.StartTrace();
            f_1();
            f_2();
            _tracer.StopTrace();
        }

        public void f2()
        {
            _tracer.StartTrace();
            f_2();
            f_1();
            _tracer.StopTrace();
        }

        private void f_1()
        {
            _tracer.StartTrace();
            Thread.Sleep(10);
            _tracer.StopTrace();
        }

        private void f_2()
        {
            _tracer.StartTrace();
            Thread.Sleep(25);
            _tracer.StopTrace();
        }
    }
}