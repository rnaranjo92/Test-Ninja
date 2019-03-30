using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }
        [Test]
        public void CalculateDemeritPoints_SpeedLimitBelow65_ReturnZero()
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(65);

            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        [TestCase(0,0)]
        [TestCase(64, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_OverTheSpeedLimit_ReturnDemeritPoints(int speed, int expectedResult)
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));

        }
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_OverMaxSpeed_ReturnArgumentOutOfRange(int speed)
        {
            Assert.That(()=> _demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}
