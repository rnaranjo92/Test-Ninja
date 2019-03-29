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
            var result = _demeritPointsCalculator.CalculateDemeritPoints(55);

            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void CalculateDemeritPoints_OverTheSpeedLimit_ReturnDemeritPoints()
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(70);

            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void CalculateDemeritPoints_OverMaxSpeed_ReturnArgumentOutOfRange()
        {
            Assert.That(()=> _demeritPointsCalculator.CalculateDemeritPoints(305), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}
