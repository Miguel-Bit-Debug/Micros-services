using Gateway.Domain.DTOs.Request;

namespace Gateway.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> CreateAccount(AccountRequestDTO request);
        Task<string> Login(LoginRequestDTO request);
    }
}
