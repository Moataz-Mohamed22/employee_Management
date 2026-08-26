using EmployeeManagement.Core.DTOs.Employee;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Interfaces;

namespace EmployeeManagement.Core.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EmployeeDtos>> GetAllAsync()
    {
        var employees = await _repository.GetAllAsync();

        return employees.Select(e => new EmployeeDtos(
            e.Id,
            e.Name,
            e.Email,
            e.Salary,
            e.Department
        ));
    }

    public async Task<EmployeeDtos?> GetByIdAsync(int id)
    {
        var employee = await _repository.GetByIdAsync(id);

        if (employee is null)
            return null;

        return new EmployeeDtos(
            employee.Id,
            employee.Name,
            employee.Email,
            employee.Salary,
            employee.Department
        );
    }

    public async Task<EmployeeDtos> CreateAsync(
        CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            Name = dto.Name,
            Email = dto.Email,
            Salary = dto.Salary,
            Department = dto.Department
        };

        await _repository.AddAsync(employee);

        await _repository.SaveChangesAsync();

        return new EmployeeDtos(
            employee.Id,
            employee.Name,
            employee.Email,
            employee.Salary,
            employee.Department
        );
    }

    public async Task<bool> UpdateAsync(
        int id,
        UpdateEmployeeDto dto)
    {
        var employee = await _repository.GetByIdAsync(id);

        if (employee is null)
            return false;

        employee.Name = dto.Name;
        employee.Email = dto.Email;
        employee.Salary = dto.Salary;
        employee.Department = dto.Department;

        _repository.Update(employee);

        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await _repository.GetByIdAsync(id);

        if (employee is null)
            return false;

        _repository.Delete(employee);

        await _repository.SaveChangesAsync();

        return true;
    }
}