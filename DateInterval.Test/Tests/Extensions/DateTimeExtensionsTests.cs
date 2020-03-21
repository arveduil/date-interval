using System;
using System.Linq;
using DateInterval.Exceptions;
using DateInterval.Extensions;
using DateInterval.Model;
using NUnit.Framework;

namespace DateInterval.Test.Tests.Extensions
{
    public class DateTimeExtensionsTests
    {
        [TestCase("12.12.2020","11.11.2022",false)]
        [TestCase("12.12.1999","11.11.1998",false)]
        [TestCase("12.12.1999","11.11.1999",true)]
        [TestCase("01.01.2020","01.01.2020",true)]
        public void Given_Dates_When_IsTheSameYear_Then_ExpectedBoolIsReturned(string firstDate,string secondDate,bool expectedResult)
        {
            var first = DateTime.Parse(firstDate);
            var second = DateTime.Parse(secondDate);
            
            var result = first.IsTheSameYear(second);
            
            Assert.AreEqual(expectedResult,result);
        }
        
        [TestCase("12.12.2020","11.11.2022",false)]
        [TestCase("12.12.1999","11.11.1998",false)]
        [TestCase("12.12.1999","11.12.1999",true)]
        [TestCase("01.01.2020","01.01.2020",true)]
        public void Given_Dates_When_IsTheSameMonth_Then_ExpectedBoolIsReturned(string firstDate,string secondDate,bool expectedResult)
        {
            var first = DateTime.Parse(firstDate);
            var second = DateTime.Parse(secondDate);
            
            var result = first.IsTheSameMonth(second);
            
            Assert.AreEqual(expectedResult,result);
        }

        [TestCase("01.01.2020",DateDisplayFormat.DayMonthYear,"01.01.2020")]
        [TestCase("01.01.2020",DateDisplayFormat.DayMonth,"01.01")]
        [TestCase("01.01.2020",DateDisplayFormat.Day,"01")]
        public void When_DateToString_Then_DateIsProperlyDisplayed(string date,DateDisplayFormat format, string expectedDateString)
        {
            var dateTime = DateTime.Parse(date);
            
            var result = dateTime.ToString(format);
            
            Assert.AreEqual(expectedDateString,result);
        }
    }
}