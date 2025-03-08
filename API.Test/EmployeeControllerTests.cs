using API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace API.Test
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private EmployeeController _employeeController;

        [SetUp]
        public void SetUp() 
        {
            _employeeController = new EmployeeController();
        }
        [Test]
        public void GetEmployeeInfo()
        {
            //Arrange
            var mockItem = new API.Models.Employee
            {
                Id = 101,
                FirstName = "John",
                LastName = "W",
                Salary = "$10000",
                Department = "IT"
            };

            //Act
            var result = _employeeController.GetEmployeeDetailV1();

            //Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var returnItem = okResult?.Value as API.Models.Employee;            
            Assert.IsNotNull( returnItem );
            Assert.That(returnItem?.Id, Is.EqualTo(mockItem.Id));
            Assert.That(returnItem?.FirstName, Is.EqualTo(mockItem.FirstName));
            Assert.That(returnItem?.LastName, Is.EqualTo(mockItem.LastName));
            Assert.That(returnItem?.Salary, Is.EqualTo(mockItem.Salary));
            Assert.That(returnItem?.Department, Is.EqualTo(mockItem.Department));
        }
    }
}