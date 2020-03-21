using System;
using DateInterval.Exceptions;

namespace DateInterval.Validators
{
    public static class InputValidator
    {
        private const int ArgumentsCount = 2;
        
        public static void ValidateArgs(string[] args)
        {
            if (args.Length != ArgumentsCount)
            {
                throw new ArgumentCountException($"Given {args.Length} arguments. {ArgumentsCount} arguments are needed.");
            }
        }
    }
}