using EmployeeManagement.Core.DTOs.Auth;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Interfaces;

namespace EmployeeManagement.Core.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;

    public AuthService(
        IUserRepository repository,
        IPasswordHasher passwordHasher,
        IJwtService jwtService)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<LoginResponseDto> RegisterAsync(
        RegisterDto dto)
    {
        var exists = await _repository.ExistsByEmailAsync(dto.Email);

        if (exists)
            throw new InvalidOperationException(
                "Email is already registered.");

        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = _passwordHasher.HashPassword(dto.Password),
            Role = "Employee"
        };

        await _repository.AddAsync(user);

        await _repository.SaveChangesAsync();

        return new LoginResponseDto(
            user.Id,
            user.Username,
            user.Email,
            user.Role,
            string.Empty
        );
    }

    public async Task<LoginResponseDto?> LoginAsync(
        LoginDto dto)
    {
        var user = await _repository.GetByEmailAsync(dto.Email);

        if (user is null)
            return null;

        var validPassword = _passwordHasher.VerifyPassword(
            dto.Password,
            user.PasswordHash);

        if (!validPassword)
            return null;

        var token = _jwtService.GenerateToken(user);

        return new LoginResponseDto(
            user.Id,
            user.Username,
            user.Email,
            user.Role,
            token
        );
    }
}