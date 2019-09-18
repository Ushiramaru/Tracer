using System.IO;
using Serialization;
using Tracer;

namespace ConsoleApp.Output
{
    public class FileOut : IOutput
    {
        public ISerializer Serializer { get; set; }
        public void Write(TraceResult tr)
        {
            File.WriteAllText("D:\\Tracer\\serialize", Serializer.Serialize(tr));
        }
    }
}