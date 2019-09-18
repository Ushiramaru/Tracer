using Tracer;

namespace Serialization
{
    public interface ISerializer
    {
        string Serialize(TraceResult tr);
    }
}