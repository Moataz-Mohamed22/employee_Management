using EmployeeManagement.Core.DTOs.Auth;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        try
        {
            var result = await _service.RegisterAsync(dto);

            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var result = await _service.LoginAsync(dto);

        if (result is null)
            return Unauthorized(new
            {
                message = "Invalid email or password."
            });

        return Ok(result);
    }
}