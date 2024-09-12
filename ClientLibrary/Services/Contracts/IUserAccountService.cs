using BaseLibrary.DTOs;
using BaseLibrary.Responses;


namespace ClientLibrary.Services.Contracts
{
    public interface IUserAccountService
    {
        Task<GeneralResponse> CreateAnysc(Register user);
        Task<LoginResponse> SignInAnysc(Login user);
        Task<LoginResponse> RefreshTokenAnysc(RefreshToken user);
        Task<WeatherForecast[]> GetWheatherForecast();

    }
}
