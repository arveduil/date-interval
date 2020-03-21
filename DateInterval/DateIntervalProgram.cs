using System;
using DateInterval.Exceptions;
using DateInterval.Extensions;
using DateInterval.Validators;
using DateInterval.Writers;

namespace DateInterval
{
    public class DateIntervalProgram
    {
        public IDataWriter DataWriter { get; set; }

        public DateIntervalProgram(IDataWriter dataWriter)
        {
            DataWriter = dataWriter;
        }

        public void Run(string[] args)
        {
            try
            {
                InputValidator.ValidateArgs(args);
            
                var start = args[0].Parse();
                var end = args[1].Parse();

                var dateInterval = new Model.DateInterval(start, end);
            
                DataWriter.Write(dateInterval.ToString());
            }
            catch (Exception e) when(e is ArgumentCountException || e is ArgumentParseException || e is IncorrectDateIntervalArgumentsException)
            {
                DataWriter.Write(e.Message);
            }
            catch (Exception e)
            {
                DataWriter.Write("Unexpected error occured. DateInterval ends.");
            }
        }
    }
}