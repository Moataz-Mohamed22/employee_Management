using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Core.DTOs.Auth;

public record RegisterDto(
    [param: Required]
    [param: StringLength(50, MinimumLength = 3)]
    string Username,

    [param: Required]
    [param: EmailAddress]
    string Email,

    [param: Required]
    [param: MinLength(6)]
    string Password
);

public record LoginDto(
    [param: Required]
    string Email,

    [param: Required]
    string Password
);

public record LoginResponseDto(
    int Id,
    string Username,
    string Email,
    string Role,
    string Token
);