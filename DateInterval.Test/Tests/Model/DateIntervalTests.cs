using System;
using DateInterval.Exceptions;
using NUnit.Framework;

namespace DateInterval.Test.Tests.Model
{
    public class DateIntervalTests
    {
        [TestCase("01.01.2020","01.01.1999","Start date is earlier than end date.")]
        public void Given_StartDateBefore_Then_ProgramWritesErrorMessage(string firstDate,
            string secondDate, string exceptionMessage)
        {
            var start = DateTime.Parse(firstDate);
            var end = DateTime.Parse(secondDate);
            
            var exception = Assert.Throws<IncorrectDateIntervalArgumentsException>( () => new DateInterval.Model.DateInterval(start,end));
            
            Assert.AreEqual(exceptionMessage,exception.Message);
        }

    }
}