using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        [Test]
        public void DeleteEmployee_TakesIdAndDeleteEmployee_DeleteEmployee()
        {
            var db = new Mock<IEmployeeRepository>();
            var controller = new EmployeeController(db.Object);

            controller.DeleteEmployee(1);
            db.Verify(d => d.DeleteEmployee(1));
        }
        [Test]
        public void DeleteEmployee_WhenCalled_ReturnRedirectToActionMethod()
        {
            var db = new Mock<IEmployeeRepository>();
            var controller = new EmployeeController(db.Object);

            var result = controller.DeleteEmployee(1);
            Assert.That(result, Is.InstanceOf<RedirectResult>());            
        }

    }
}
