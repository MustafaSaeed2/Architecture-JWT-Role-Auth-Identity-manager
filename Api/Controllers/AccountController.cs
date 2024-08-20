
using Application.Contractes;
using Application.DTOs.Requst.Account;
using Application.DTOs.Respons;
using Application.DTOs.Respons.Account;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccount account) : ControllerBase
    {
        [HttpPost("identity/create")]
        public async Task <ActionResult<GeneralRespons>>CreateAccount(CreateAccountDTO  model)

        {
            if (!ModelState.IsValid) 
                
                return BadRequest("Model cannot null");

            return Ok(await account.CreateAccountAsync(model));

        }
        [HttpPost("identity/login")]
        public async Task <ActionResult <GeneralRespons>>LoginAccount(LoginDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest("model connot be null");
            return Ok (await account.LoginAccountAsync(model));

        }
        [HttpPost ("identity/refresh-token")]
        public async Task  <ActionResult<GeneralRespons>> RefreshToken (RefreshTokenDTO model )
        {
            if (!ModelState.IsValid)
                return BadRequest("model cannot be null");
            return Ok (await account.RefreshtokenAsync(model));

        }
        [HttpPost("identity/role/create")]
        public async Task<ActionResult<GeneralRespons>> CreateRole(CreateRoleDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model connot be null");
            return Ok (await account.CreateRoleasync(model));
        }
        [HttpGet("identity/role/list")]
        public async Task<ActionResult<IEnumerable<GetRoleDTO>>> GetRoles()
            =>Ok(await account.GetRolesAsync());

        [HttpPost("/setting")]
        public async Task<IActionResult> CreatAdmin()
        {
            await account.CreateAdmin();
            return Ok();   
            
        }
        [HttpGet("identity/users-with-roles")]
        public async Task<ActionResult<IEnumerable<GetUesrsWithRolesResponseDTO>>>GetUserwithRoles()
            =>Ok (await account.GetUesrsWithRolesAsync());
        [HttpPost ("identity/change-role")]
        public async Task <ActionResult <GeneralRespons>>changeUserRols(ChangeUserRoleRequestDTO model)=>
            Ok (await account.ChangeUesrRoleAsync(model));

           
    }
}
