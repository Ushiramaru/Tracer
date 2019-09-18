using System;
using System.Threading;
using NUnit.Framework;
using Tracer;
using Thread = System.Threading.Thread;

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
        [Test]
        public void Test3()
        {
            Tracer.Tracer tracer = new Tracer.Tracer();
            Thread thread = new Thread(new ParameterizedThreadStart(f1));
            thread.Start(tracer);
            ff(tracer);
            Thread.Sleep(100);
            Assert.AreEqual(2, tracer.GetTraceResult().Threads.Length);
        }
        
        [Test]
        public void Test4()
        {
            Tracer.Tracer tracer = new Tracer.Tracer();
            f2(tracer);
            Assert.AreEqual("Tests.Tests", tracer.GetTraceResult().Threads[0].Methods[0].ClassName);
        }

        private void f2(Tracer.Tracer tracer)
        {
            tracer.StartTrace();
            tracer.StopTrace();
        }

        private void f1(Object tracer)
        {
            f((Tracer.Tracer) tracer);
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