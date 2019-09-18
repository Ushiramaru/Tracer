using System;
using Serialization;
using Tracer;

namespace ConsoleApp.Output
{
    public class ConsoleOut : IOutput
    {
        public ISerializer Serializer { get; set; }
        public void Write(TraceResult tr)
        {
            Console.WriteLine(Serializer.Serialize(tr));
        }
    }
}