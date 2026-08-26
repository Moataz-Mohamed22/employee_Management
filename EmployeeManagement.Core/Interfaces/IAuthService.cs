using EmployeeManagement.Core.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> RegisterAsync (RegisterDto dto);
        Task<LoginResponseDto> LoginAsync (LoginDto dto);

    }
}
