using NUnit.Framework;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class MathTests
    {
        [Test]
        public void Add_WhenCalled_ReturnSum()
        {
            var math = new Math();

            var result = math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnFirstArgument()
        {
            var math = new Math();

            var result = math.Max(2, 1);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnSecondArgument()
        {
            var math = new Math();

            var result = math.Max(1, 2);

            Assert.That(result, Is.EqualTo(2));
        }
        [Test]
        public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        {
            var math = new Math();

            var result = math.Max(1, 1);

            Assert.That(result, Is.EqualTo(1));
        }
    }
}
