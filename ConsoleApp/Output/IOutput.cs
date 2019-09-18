using Serialization;
using Tracer;

namespace ConsoleApp.Output
{
    public interface IOutput
    {
        ISerializer Serializer { get; set; }
        void Write(TraceResult tr);
    }
}