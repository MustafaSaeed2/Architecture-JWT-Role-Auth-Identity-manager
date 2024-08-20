using Application.DTOs.Requst.Account;
using Application.DTOs.Respons;
using Application.DTOs.Respons.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contractes
{
    public interface IAccount
    {
        Task CreateAdmin();
        Task<GeneralRespons> CreateAccountAsync(CreateAccountDTO model);
        
        Task<LoginRespons> LoginAccountAsync(LoginDTO  model);

        Task <LoginRespons> RefreshtokenAsync (RefreshTokenDTO  model);
        Task<GeneralRespons> CreateRoleasync(CreateRoleDTO model);
    
        Task<IEnumerable<GetRoleDTO>> GetRolesAsync();

        Task<IEnumerable<GetUesrsWithRolesResponseDTO>> GetUesrsWithRolesAsync();

        Task<GeneralRespons> ChangeUesrRoleAsync(ChangeUserRoleRequestDTO model);
    }
}
