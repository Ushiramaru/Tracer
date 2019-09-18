
using System;
using System.Threading;
using ConsoleApp.FakeClass;
using ConsoleApp.Output;
using Serialization;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Tracer.Tracer tracer = new Tracer.Tracer();
            Class1 c1 = new Class1(tracer);
            Class2 c2 = new Class2(tracer);
            c2.f1();
            c1.f2();
            c1.f1();
            c2.f2();
            Thread thread = new Thread(new ParameterizedThreadStart(Some));
            thread.Start(tracer);
            Thread.Sleep(1000);
            
            IOutput iOutput = new ConsoleOut();
            iOutput.Serializer = new TraceResultJsonSerialize();
            iOutput.Write(tracer.GetTraceResult());
            
            iOutput = new FileOut();
            iOutput.Serializer = new TraceResultXMLSerialize();
            iOutput.Write(tracer.GetTraceResult());
        }

        private static void Some(Object tracer)
        {
            Class1 c1 = new Class1((Tracer.Tracer) tracer);
            c1.f1();
            c1.f2();
        }
    }
}