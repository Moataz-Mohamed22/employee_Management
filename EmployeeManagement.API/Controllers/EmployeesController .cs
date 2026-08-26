using EmployeeManagement.Core.DTOs.Employee;
using EmployeeManagement.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }
        [HttpGet("Get-all")]
        public async Task < IActionResult> GetAll()
        {
            var employees =await _service.GetAllAsync();
            return Ok(employees);
        }
        [HttpPost("Create")] 
        public async Task<IActionResult>Create(CreateEmployeeDto dto)
        {
            var employee = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById),new {id =employee.Id},employee);
        }
        [HttpGet("Get-by-id/{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var employee = await _service.GetByIdAsync(id);
            if(employee is null)
                return NotFound();
            return Ok(employee);
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id,UpdateEmployeeDto dto) {
            var update = await _service.UpdateAsync(id, dto);
            if (!update)
                return NotFound();
            return NoContent();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete (int id)
        {
            var delete =await _service.DeleteAsync(id);
            if(!delete)
                return NotFound();
            return NoContent();
        }
    }
}
