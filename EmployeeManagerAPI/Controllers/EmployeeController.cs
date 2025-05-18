using EmployeeManagerAPI.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagerAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            this._employee = employee;
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        [Route("AllEmployees")]
        
        public async Task<IActionResult> Employees()
        {
            return Ok(await _employee.GetEmployee());
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        [Route("GetEmployeeById")]
        
        public async Task<IActionResult> Employees(int id)
        {
            return Ok(await _employee.GetEmployee(id));

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Model.Employee employee)
        {
            return Ok(await _employee.ManageEmployee(employee));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Model.Employee employee)
        {
            return Ok(await _employee.ManageEmployee(employee));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return Ok(await _employee.DeleteEmployee(id));
        }


    }
}
