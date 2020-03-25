using System;
using DateInterval.Exceptions;
using DateInterval.Extensions;
using DateInterval.Validators;
using DateInterval.Writers;
using NLog;

namespace DateInterval
{
    public class DateIntervalProgram
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();   
        
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

                Logger.Trace("Args were parsed properly.");
                
                var dateInterval = new Model.DateInterval(start, end);
            
                Logger.Trace("DateInterval was created successfully.");

                DataWriter.Write(dateInterval.ToString());
            }
            catch (Exception e) when(e is ArgumentCountException || e is ArgumentParseException || e is IncorrectDateIntervalArgumentsException)
            {
                Logger.Error(e);
                DataWriter.Write(e.Message);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                DataWriter.Write("Unexpected error occured. DateInterval ends.");
            }
        }
    }
}