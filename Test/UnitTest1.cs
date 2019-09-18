using System.Threading;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Tracer.Tracer tracer = new Tracer.Tracer();
            f(tracer);
            Assert.AreEqual(1, tracer.GetTraceResult().Threads.Length);
        }
        [Test]
        public void Test2()
        {
            Tracer.Tracer tracer = new Tracer.Tracer();
            ff(tracer);
            Assert.AreEqual(3, tracer.GetTraceResult().Threads[0].Methods[0].Methods.Length);
        }

        private void f(Tracer.Tracer tracer)
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }
        private void ff(Tracer.Tracer tracer)
        {
            tracer.StartTrace();
            f(tracer);
            f(tracer);
            f(tracer);
            Thread.Sleep(100);
            tracer.StopTrace();
        }
    }
}