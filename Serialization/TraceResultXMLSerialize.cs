using Tracer;

namespace Serialization
{
    public class TraceResultXMLSerialize
    {
        private static string Serialize(Method m, string tab, string tab2)
        {
            string methods = "";
            for (int i = 0; i < m.Methods.Length; i++)
            {
                methods += Serialize(m.Methods[i], tab+"    ", tab2+"    ");
            }
            string json = "\n"+tab2+"<method name=\""+m.Name+"\" time=\""+m.Time+"ms\" class=\""+m.ClassName+"\">"+
                          methods+
                          "\n"+tab2+"</method>";
            return json;
        }

        private static string Serialize(Thread t)
        {
            string methods = "";
            for (int i = 0; i < t.Methods.Length; i++)
            {
                methods += Serialize(t.Methods[i], "            ", "        ");
            }

            string json = "\n    <thread id=\""+t.Id+"\" time=\""+t.Time+"ms"+"\">"+
                          methods+
                          "\n    </thread>";
            return json;
        }

        public static string Serialize(TraceResult tr)
        {
            string json = "<root>";
            for (int i = 0; i < tr.Threads.Length; i++)
            {
                json += Serialize(tr.Threads[i]);
            }
            json += "\n</root>";
            return json;
        }
    }
}