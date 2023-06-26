using Messagehub.Domain.Models;

namespace Messagehub.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByEmail(string email);
    }
}
