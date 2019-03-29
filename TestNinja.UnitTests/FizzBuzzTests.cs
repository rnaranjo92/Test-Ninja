using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        [SetUp]
        public void SetUp()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [Test]
        [TestCase(30)]
        [TestCase(6)]
        
        public void GetOutput_CheckIfDivisibleBy5or3orBoth_ReturnStringResult(int a)
        {
            var results = FizzBuzz.GetOutput(a);

            Assert.That(results, Does.Contain("zz"));
        }
        [Test]
        public void GetOutput_NotDivisibleBy5or3_ReturnStringResult()
        {
            var results = FizzBuzz.GetOutput(2);

            Assert.That(results, Is.EqualTo("2"));
        }
    }
}
