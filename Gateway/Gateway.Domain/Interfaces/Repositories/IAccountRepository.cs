using Gateway.Domain.Models;

namespace Gateway.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task CreateAccount(Account account);
        Task<bool> CheckAccountExists(string email);
    }
}
