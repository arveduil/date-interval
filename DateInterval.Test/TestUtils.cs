using DateInterval.Writers;

namespace DateInterval.Test
{
    public static class TestUtils
    {
        public static DateIntervalProgram CreateTestProgram( MemoryWriter memoryWriter)
        {
            return new DateIntervalProgram(memoryWriter);
        }

        public static string GetCannotParseMessage(string argument) =>
            $"Cannot parse: {argument}, format accepted: dd.MM.yyyy .";
        
        public static string GetWrongCountMessage(int count) =>
            $"Given {count} arguments. 2 arguments are needed."; 
        
        public static string GetUnexpectedErrorMessage() =>
            "Unexpected error occured. DateInterval ends.";
    }
}