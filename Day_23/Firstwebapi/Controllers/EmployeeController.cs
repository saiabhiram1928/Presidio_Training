using Firstwebapi.Exceptions;
using Firstwebapi.Interfaces;
using Firstwebapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Firstwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Employee>>> GetAllEmployeeApi()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();
                return employees.ToList();
            }catch( NoEmployeesFoundException nefx)
            {
                return NotFound(new ErrorModel(404, nefx.Message));
            }
           
        }
        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployeeApi(int id, string phone)
        {
            try
            {
                var employee = await _employeeService.UpdateEmployeePhone(id, phone);
                return Ok(employee);
            }catch(NoSuchEmployeeException nsefex)
            {
                return NotFound(nsefex.Message);
               
            }
        }
        [Route("GetEmployeeByPhone")]
        [HttpGet]
        public async Task<ActionResult<Employee>> GetEmployeeByPhoneApi(string phone)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByPhone(phone);
                return Ok(employee);
            }catch (NoSuchEmployeeException nseex)
            {
                return NotFound(nseex.Message);
            }
        }
    }
}
