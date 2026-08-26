using EmployeeManagement.Core.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDtos>> GetAllAsync();

        Task<EmployeeDtos?> GetByIdAsync(int id);

        Task<EmployeeDtos> CreateAsync(CreateEmployeeDto dto);

        Task<bool> UpdateAsync(int id, UpdateEmployeeDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
