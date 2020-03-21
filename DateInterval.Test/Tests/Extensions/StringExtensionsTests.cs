using DateInterval.Exceptions;
using DateInterval.Extensions;
using NUnit.Framework;

namespace DateInterval.Test.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [TestCase("test")]
        [TestCase("")]
        [TestCase("01/01/2020")]
        public void Given_WrongDateFormat_When_Parse_Then_ExceptionIsThrown(string date)
        {
            var exception = Assert.Throws<ArgumentParseException>( () => date.Parse());
            
            Assert.AreEqual(TestUtils.GetCannotParseMessage(date),exception.Message);
        }
    }
}