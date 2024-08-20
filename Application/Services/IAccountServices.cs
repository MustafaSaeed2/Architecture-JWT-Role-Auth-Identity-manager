

using Application.DTOs.Requst.Account;
using Application.DTOs.Respons.Account;
using Application.DTOs.Respons;

namespace Application.Services
{
  public interface IAccountServices
    {
        Task CreateAdmin();
        Task<GeneralRespons> CreateAccountAsync(CreateAccountDTO model);

        Task<LoginRespons> LoginAccountAsync(LoginDTO model);

        Task<LoginRespons> RefreshtokenAsync(RefreshTokenDTO model);
        Task<GeneralRespons> CreateRoleasync(CreateRoleDTO model);

      

        Task<IEnumerable<GetUesrsWithRolesResponseDTO>> GetUesrsWithRolesAsync();

        Task<GeneralRespons> ChangeUesrRole(ChangeUserRoleRequestDTO model);
    }
}
