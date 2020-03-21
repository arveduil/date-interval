using System.Linq;
using DateInterval.Writers;
using NUnit.Framework;

namespace DateInterval.Test.Tests
{
    public class E2ETests
    {
        [TestCase("01.01.2020","02.02.2022","01.01.2020 - 02.02.2022")]
        [TestCase("01.01.2020","02.02.2020","01.01 - 02.02.2020")]
        [TestCase("01.01.2020","02.01.2020","01 - 02.01.2020")]
        [TestCase("01.01.2020","01.01.2020","01 - 01.01.2020")]
        public void Given_HappyCases_Then_ProgramWritesCorrectInterval(string firstArgument,
            string secondArgument, string expectedOutput)
        {
            var memory = new MemoryWriter();
            var program = TestUtils.CreateTestProgram(memory);
            
            program.Run(new[]{firstArgument,secondArgument});
            
            Assert.AreEqual(expectedOutput,memory.ReadLast());
        } 
        

        [TestCase(null,null)]
        public void Given_CorruptedData_Then_ProgramWritesCorrectMessage(string firstArgument,string secondArgument)
        {
            var memory = new MemoryWriter();
            var program = TestUtils.CreateTestProgram(memory);
            
            program.Run(new[]{firstArgument,secondArgument});

            Assert.AreEqual(TestUtils.GetUnexpectedErrorMessage(), memory.ReadLast());
        }

        [TestCase("01.01.2020","01.01.1999","Start date is earlier than end date.")]
        public void Given_StartDateBefore_Then_ProgramWritesErrorMessage(string firstArgument,
            string secondArgument, string expectedOutput)
        {
            var memory = new MemoryWriter();
            var program = TestUtils.CreateTestProgram(memory);
            
            program.Run(new[]{firstArgument,secondArgument});
            
            Assert.AreEqual(expectedOutput,memory.ReadLast());
        }
        
        [TestCase("test","")]
        [TestCase("01/01/2020","")]
        public void Given_WrongFirstArgument_Then_ProgramWritesErrorMessage(string firstArgument,string secondArgument)
        {
            var memory = new MemoryWriter();
            var program = TestUtils.CreateTestProgram(memory);
            
            program.Run(new[]{firstArgument,secondArgument});
            
            Assert.AreEqual(TestUtils.GetCannotParseMessage(firstArgument),memory.ReadLast());
        } 
        
        [TestCase("01.01.2020","test")]
        [TestCase("01.01.2020","")]
        public void Given_WrongSecondArgument_Then_ProgramWritesErrorMessage(string firstArgument,string secondArgument)
        {
            var memory = new MemoryWriter();
            var program = TestUtils.CreateTestProgram(memory);
            
            program.Run(new[]{firstArgument,secondArgument});
            
            Assert.AreEqual(TestUtils.GetCannotParseMessage(secondArgument),memory.ReadLast());
        }

        [TestCase(4)]
        [TestCase(3)]
        [TestCase(1)]
        [TestCase(0)]
        public void Given_WrongParameterCount_Then_ProgramWritesErrorMessage(int count)
        {
            var memory = new MemoryWriter();
            var program = TestUtils.CreateTestProgram(memory);
            var parameters = TestDataSources.StringEmitter().Take(count).ToArray();
            
            program.Run(parameters);
            
            Assert.AreEqual(TestUtils.GetWrongCountMessage(count),memory.ReadLast());
        }


    }
}