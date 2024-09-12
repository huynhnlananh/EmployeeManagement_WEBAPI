/*
using BaseLibrary.DTOs;
using BaseLibrary.Responses;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Services.Implementations
{
    public class UserAccountService (GetHttpClient getHttpClient) : IUserAccountService
    {
        public const string AuthUrl = "api/authentication";



        public async Task<GeneralResponse> CreateAnysc(Register user)
        {
            var httpClient = getHttpClient.GetPublicHttpClient();
            var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/register", user);
            if (!result.IsSuccessStatusCode)
                return new GeneralResponse(false, "Error occurred");
            return await result.Content.ReadFromJsonAsync<GeneralResponse>()!;
        }



        public async Task<LoginResponse> SignInAnysc(Login user)
        {
            var httpClient = getHttpClient.GetPublicHttpClient();

            var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/login", user);
            if (!result.IsSuccessStatusCode)
                return new LoginResponse(false, "Error occurred");
            else 
                return await result.Content.ReadFromJsonAsync<LoginResponse>()!;
        }




        public Task<LoginResponse> RefreshTokenAnysc(RefreshToken user)
        {
            throw new NotImplementedException();
        }



        

        public async Task<WeatherForecast[]> GetWheatherForecast()
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var result = await httpClient.GetFromJsonAsync<WeatherForecast[]>("api/weatherforecast");
            return result!;
        }
    }
}
*/

using BaseLibrary.DTOs;
using BaseLibrary.Responses;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ClientLibrary.Services.Implementations
{
    public class UserAccountService : IUserAccountService
    {
        private readonly GetHttpClient _getHttpClient;
        public const string AuthUrl = "api/authentication";

        public UserAccountService(GetHttpClient getHttpClient)
        {
            _getHttpClient = getHttpClient;
        }

        public async Task<GeneralResponse> CreateAnysc(Register user)
        {
            var httpClient = _getHttpClient.GetPublicHttpClient();
            var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/register", user);
            if (!result.IsSuccessStatusCode)
                return new GeneralResponse(false, "Error occurred");
            return await result.Content.ReadFromJsonAsync<GeneralResponse>();
        }

        public async Task<LoginResponse> SignInAnysc(Login user)
        {
            var httpClient = _getHttpClient.GetPublicHttpClient();
            var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/login", user);
            if (!result.IsSuccessStatusCode)
                return new LoginResponse(false, "Error occurred");
            return await result.Content.ReadFromJsonAsync<LoginResponse>();
        }

        public async Task<LoginResponse> RefreshTokenAnysc(RefreshToken user)
        {
            var httpClient = _getHttpClient.GetPublicHttpClient();
            var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/refresh", user);
            if (!result.IsSuccessStatusCode)
                return new LoginResponse(false, "Error occurred while refreshing token");
            return await result.Content.ReadFromJsonAsync<LoginResponse>();
        }

        public async Task<WeatherForecast[]> GetWheatherForecast()
        {
            var httpClient = await _getHttpClient.GetPrivateHttpClient();
            return await httpClient.GetFromJsonAsync<WeatherForecast[]>("api/weatherforecast");
        }
    }
}
