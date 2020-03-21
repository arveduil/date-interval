using System.Linq;
using DateInterval.Exceptions;
using DateInterval.Validators;
using DateInterval.Writers;
using NUnit.Framework;

namespace DateInterval.Test.Tests.Validators
{
    public class InputValidatorTests
    {
        [TestCase(4)]
        [TestCase(3)]
        [TestCase(1)]
        [TestCase(0)]
        public void Given_WrongParameters_Then_ExceptionIsThrown(int count)
        {
            var parameters = TestDataSources.StringEmitter().Take(count).ToArray();

            var exception = Assert.Throws<ArgumentCountException>( () => InputValidator.ValidateArgs(parameters));
            
            Assert.AreEqual(TestUtils.GetWrongCountMessage(count),exception.Message);
        }
                        
        [TestCase(2)]
        public void Given_2Parameters_Then_NothingHappens(int count)
        {
            var parameters = TestDataSources.StringEmitter().Take(count).ToArray();

            InputValidator.ValidateArgs(parameters);
        }
    }
}