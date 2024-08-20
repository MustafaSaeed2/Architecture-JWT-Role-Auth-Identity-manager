using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Components.Authorization;
using Application.DTOs.Requst.Account;
using Microsoft.IdentityModel.Tokens;
using Application.DTOs.Respons.Account;
namespace Application.Extensions
{
    public class CustomAuthenticationStateProvider(LocalStorageServices localStorageServices) : AuthenticationStateProvider
    {
        private readonly ClaimsPrincipal anonymous = new(new ClaimsIdentity());
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var tokenModel = await localStorageServices.GetModelFromToken();
            if (string.IsNullOrEmpty(tokenModel.tokne))
                return await Task.FromResult(new AuthenticationState(anonymous));
            var getuserclaims = DecryptToken(tokenModel.tokne);
            if (getuserclaims == null)
                return await Task.FromResult(new AuthenticationState(anonymous));
            var claimsPrincipal = SetClaimPrincipal(getuserclaims);
            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }
        public async Task UpdateAuthenticationState(LocalStorageDTO localStorageDTO)
        {
            var claimsPrincipal = new ClaimsPrincipal();
            if (localStorageDTO.tokne != null ||localStorageDTO.Refresh != null)
            {
                await localStorageServices.SetBrowserLocalStorage(localStorageDTO);
                var getuserClaims = DecryptToken(localStorageDTO.tokne);
                claimsPrincipal= SetClaimPrincipal(getuserClaims);

            }
            else
            {
                await localStorageServices.RemoveTokenFromBrowserLocalStroage();

            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));   
        }
        public static ClaimsPrincipal SetclaimsPrincipal (userClaimsDTO claims)
        {
            if (claims.Email is null) return new ClaimsPrincipal();
            return new ClaimsPrincipal(new ClaimsIdentity(
                [
                new (ClaimTypes.Name,claims.UserName),
                new (ClaimTypes.Email,claims.Email) ,
                new (ClaimTypes.Role,claims.Role),
                new Claim("Fullname", claims.Fullname)


                ],constant.AuthenticationType));


                
        }
        public static userClaimsDTO DecryptToken(string jwtToken)
        {
            try {        if(!string.IsNullOrEmpty(jwtToken))return new userClaimsDTO();
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);
            var name  = token .Claims.FirstOrDefault(_=>_.Type==ClaimTypes.Name )!.Value; 
            var email  = token .Claims.FirstOrDefault(_=>_.Type==ClaimTypes.Email )!.Value; 
            var role = token .Claims.FirstOrDefault(_=>_.Type==ClaimTypes.Role )!.Value;
            var fullname = token.Claims.FirstOrDefault(_ =>_.Type == "fullname")!.Value;
            return new userClaimsDTO (fullname, name, email, role);}
            catch { return null!; }
            
     
        }
    }
}
