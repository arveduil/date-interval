using System.Collections.Generic;

namespace DateInterval.Test
{
    public class TestDataSources
    {
        public static IEnumerable<string> StringEmitter()
        {
            for (int i = 0;; i++)
            {
                yield return i.ToString();
            }
        }
    }
}