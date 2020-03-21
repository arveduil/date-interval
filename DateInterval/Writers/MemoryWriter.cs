using System.Collections.Generic;
using System.Linq;

namespace DateInterval.Writers
{
    public class MemoryWriter : IDataWriter
    {
        private List<string> _memory= new List<string>();
        
        public void Write(string content)
        {
           _memory.Add(content);
        }
        
        public string ReadLast()
        {
            return _memory.Last();
        }
    }
}