using EmployeeDetailsEntity.Models.emp;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetailsEntity.Controllers
{

    [ApiController]
    [Route("EmployeeDetailsApi")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }


        [HttpPost]
        public IActionResult InsertEmployee(Employee employee)
        {
            var result = _employee.InsertEmployee(employee);
            return Ok(result);
        }


        [HttpGet]
        public IActionResult GetEmployee(int id)
        {
            var result = _employee.GetEmployee(id);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var result = _employee.DeleteEmployee(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            var result = _employee.UpdateEmployee(employee);
            return Ok(result);
        }


    }
}
