using API.Models;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class EmployeeController : ControllerBase
    {
        List<string> DepartmentList = new List<string> { "IT","HR"};
        
        [HttpGet("GetEmployeeDetails")]
        [MapToApiVersion("1.0")]
        public IActionResult GetEmployeeDetailV1()
        {
            return Ok(new Employee
            {
                Id = 101,
                FirstName = "John",
                LastName="W",
                Salary="$10000",
                Department="IT"
            });
        }

        
        [HttpGet("GetEmployeeDetails")]
        [MapToApiVersion("2.0")]
        public IActionResult GetEmployeeDetailV2()
        {
            return Ok(new
            {
                Id = 101,
                Firstname = "John",
                LastName = "W",
                Salary = "$10000",
                Department = DepartmentList
            });
        }

    }
}
