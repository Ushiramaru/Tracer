using Tracer;

namespace Serialization
{
    public class TraceResultJsonSerialize : ISerializer
    {
        private string Serialize(Method m, string tab, string tab2)
        {
            string methods = "";
            for (int i = 0; i < m.Methods.Length; i++)
            {
                methods += Serialize(m.Methods[i], tab+"    ", tab2+"    ");
                if (i != (m.Methods.Length - 1))
                {
                    methods += ",";
                }
            }
            string json = "\n"+tab2+"{"+
                          "\n"+tab+"\"name\": "+m.Name+
                          ",\n"+tab+"\"class\": "+m.ClassName+
                          ",\n"+tab+"\"time\": "+m.Time+"ms"+
                          ",\n"+tab+"\"methods\": ["+
                          (methods == ""?"]":methods+"\n"+tab+"]")+
                          "\n"+tab2+"}";
            return json;
        }

        private string Serialize(Thread t)
        {
            string methods = "";
            for (int i = 0; i < t.Methods.Length; i++)
            {
                methods += Serialize(t.Methods[i], "                    ", "                ");
                if (i != (t.Methods.Length - 1))
                {
                    methods += ",";
                }
            }

            string json = "\n        {"+
                          "\n            \"id\": "+t.Id+
                          "\n            \"time\": "+t.Time+
                          "\n            \"methods\": ["+
                          (methods == ""?"]":methods+"\n            ]")+
                          "\n        }";
            return json;
        }

        public string Serialize(TraceResult tr)
        {
            string json = "{"+
                          "\n    \"threads\": [";
            for (int i = 0; i < tr.Threads.Length; i++)
            {
                json += Serialize(tr.Threads[i]);
                if (i != tr.Threads.Length - 1)
                {
                    json += ",";
                }
            }
            json += "\n    ]\n}";
            return json;
        }
    }
}