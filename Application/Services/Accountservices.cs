using Application.DTOs.Requst.Account;
using Application.DTOs.Respons;
using Application.DTOs.Respons.Account;
using Application.Extensions;
using System.Net.Http.Json;


namespace Application.Services
{
    public class Accountservices(HttpClientServices httpClientServices) : IAccountServices
    {
        public async Task<GeneralRespons> ChangeUesrRole(ChangeUserRoleRequestDTO model)
        {
            try
            {
                var publicclient = await httpClientServices.GetPrivateClient();
                var response = await publicclient .PostAsJsonAsync(constant.ChangeUserRoleRoute,model); 
                string error = CheckResponseStatus(response);
                if(!string .IsNullOrEmpty(error)) 
                    return new GeneralRespons(false,error);
                var result = await response.Content.ReadFromJsonAsync<GeneralRespons>();
                return result!;
            }
            catch (Exception ex) { return new GeneralRespons(false, ex.Message); }
        }

        public Task<GeneralRespons> CreateAccountAsync(CreateAccountDTO model)
        {
          
        }

        public Task CreateAdmin()
        {
            throw new NotImplementedException();
        }

        public Task<GeneralRespons> CreateRoleasync(CreateRoleDTO model)
        {
            throw new NotImplementedException();
        }



    

        public async Task<LoginRespons> LoginAccountAsync(LoginDTO model)
        {
            try
            {
                var publicClient = httpClientServices.GetPublicClient();
                var response = await publicClient.PostAsJsonAsync(constant.LoginRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    return new LoginRespons(flag: false, message: error);
                var result = await response.Content.ReadFromJsonAsync<LoginRespons>();
                return result;

            }

            catch (Exception ex)
            {
                return new LoginRespons(flag: false, message: ex.Message);
            }
        }

        public async Task<GeneralRespons> RegisterAccountAsync(CreateAccountDTO model)
        {
            try
            {
                var publicClient = httpClientServices.GetPublicClient();
                var response = await publicClient.PostAsJsonAsync(constant.RegisterRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    return new GeneralRespons(flag: false, message: error);
                var result = await response.Content.ReadFromJsonAsync<GeneralRespons>();
                return result!;
            }
            catch (Exception ex)
            {
                return new GeneralRespons(flag: false, message: ex.Message);
            }
        }
        private static string CheckResponseStatus(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                return $"sorry unknow error occured .{Environment.NewLine}error discription:{Environment.NewLine}:status code :{response.StatusCode}{Environment.NewLine}Reason Phrase : {response.ReasonPhrase} ";

            else
                return null;

        }
        public async Task CreateAdminFristStart()
        {
            try
            {
                var client = httpClientServices.GetPublicClient();
                await client.PostAsync(constant.CreateAdminRoute, null);
            }
            catch { }
        }
        public async Task<IEnumerable<GetRoleDTO>> GetRolesAsync()
        {
            try
            {
                var privateClient = await httpClientServices.GetPrivateClient();
                var response = await privateClient.GetAsync(constant.GetRolesRoute);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    throw new Exception(error);
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<GetRoleDTO>>();
                return result!;


            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        public  IEnumerable<GetRoleDTO>GetDefaultRoles()
        {
        var list = new List<GetRoleDTO>(); 
            list.Clear();   
            list .Add(new GetRoleDTO(1.ToString(),constant.Role.Admin));
            list .Add(new GetRoleDTO(1.ToString(),constant.Role.User));
         return list;
        }
        public async Task<IEnumerable<GetUesrsWithRolesResponseDTO>> GetUesrsWithRolesAsync()
        {
            try
            {
                var privateClient = await httpClientServices.GetPrivateClient();
                var response = await privateClient.GetAsync(constant.GetUserWithRolesRoute);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    throw new Exception(error);
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<GetUesrsWithRolesResponseDTO>>();
                return result!; 

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<LoginRespons> RefreshtokenAsync(RefreshTokenDTO model)
        {
            try
            {
                var publicClient = httpClientServices.GetPublicClient();
                var response = await publicClient .PostAsJsonAsync(constant.RefreshTokenRoute,model);   
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    return new LoginRespons(false, error);
                var reslut = await response.Content.ReadFromJsonAsync<LoginRespons>();
                return reslut;

            }
            catch (Exception ex)
            {
                return new LoginRespons(false,ex.Message);
            }
        }

    }
}
