using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Core.DTOs.Employee;

public record EmployeeDtos(
    int Id,
    string Name,
    string Email,
    decimal Salary,
    string Department);

public record CreateEmployeeDto(
    [property: Required]
    [property: StringLength(100, MinimumLength = 2)]
    string Name,

    [property: Required]
    [property: EmailAddress]
    [property: StringLength(150)]
    string Email,

    [property: Range(0.01, double.MaxValue)]
    decimal Salary,

    [property: Required]
    [property: StringLength(100, MinimumLength = 2)]
    string Department
);

public record UpdateEmployeeDto(
    [property: Required]
    [property: StringLength(100, MinimumLength = 2)]
    string Name,

    [property: Required]
    [property: EmailAddress]
    [property: StringLength(150)]
    string Email,

    [property: Range(0.01, double.MaxValue)]
    decimal Salary,

    [property: Required]
    [property: StringLength(100, MinimumLength = 2)]
    string Department
);