using System;

namespace DateInterval.Writers
{
    public class ConsoleWriter : IDataWriter
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}