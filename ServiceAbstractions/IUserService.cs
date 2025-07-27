using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractions
{
    public interface IUserService
    {
        Task RegisterUserAsync(RegisterUserDto dto);
        Task<string> LoginUserAsync(LoginUserDto dto);
    }
}
