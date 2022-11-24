using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASupport.TestEvents
{
    public class Entry
    {
        public string level { get; set; }
        public int lineNumber { get; set; }
        public string source { get; set; }
        public string text { get; set; }
        public string timestamp { get; set; }
        public string url { get; set; }
    }


    public class JsonDataErrors
    {
        public Entry entry { get; set; }
    }
}
