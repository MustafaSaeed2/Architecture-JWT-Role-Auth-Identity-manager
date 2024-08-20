using Application.DTOs.Requst.Account;
using NetcodeHub.Packages.Extensions.LocalStorage;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using Microsoft.IdentityModel.Tokens;
namespace Application.Extensions
{
    public class LocalStorageServices(ILocalStorageService localStorageService)
    {
        private async Task <string> GetBrowserLocalStorage()
        {
            var tokenModel = await localStorageService.GetEncryptedItemAsStringAsync(constant.BrowserStorageKey);
            return tokenModel!;

        }
        public async Task <LocalStorageDTO>GetModelFromToken()
        {
            try
            {
                string token = await GetBrowserLocalStorage();
                if(string .IsNullOrEmpty(token)||string .IsNullOrWhiteSpace(token))

                        return new LocalStorageDTO();

                return DeserializeJsonString<LocalStorageDTO>(token);    

            }
            catch
            {
                return new LocalStorageDTO();
            }
        }
        public async Task SetBrowserLocalStorage( LocalStorageDTO localStorageDTO)
       {
            try
            {
                string token = serializeObj(localStorageDTO);
                await localStorageService.SaveAsEncryptedStringAsync(constant.BrowserStorageKey, token);
            }
            catch { }
        }
            public async Task RemoveTokenFromBrowserLocalStroage()
            =>await localStorageService.DeleteItemAsync(constant.BrowserStorageKey);
            private static string serializeObj<T>(T modelObject)
            =>JsonSerializer.Serialize(modelObject,JsonOptions())!;
        private static T DeserializeJsonString<T>(string JsonString)
            => JsonSerializer.Deserialize<T>(JsonString, JsonOptions())!;
                private static JsonSerializerOptions JsonOptions()
                {
            return new JsonSerializerOptions
                 {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                UnmappedMemberHandling=JsonUnmappedMemberHandling.Skip
                };
                }
                
    }
}
