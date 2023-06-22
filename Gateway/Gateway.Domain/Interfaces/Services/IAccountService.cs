using Gateway.Domain.DTOs.Request;

namespace Gateway.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        Task<string> CreateAccount(AccountRequestDTO request);
    }
}
