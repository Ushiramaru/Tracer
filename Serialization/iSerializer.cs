using Tracer;

namespace Serialization
{
    public interface iSerializer
    {
        string Serialize(TraceResult tr);
    }
}