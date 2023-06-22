using Gateway.Domain.Interfaces.Repositories;
using Gateway.Domain.Models;
using Gateway.InfraData.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Gateway.InfraData.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMongoCollection<Account> _collection;

        public AccountRepository(IMongoDbContext dbContext)
        {
            _collection = dbContext.Collection<Account>();
        }

        public async Task<bool> CheckAccountExists(string email)
        {
            var account = await _collection.Find(x => x.Email == email).FirstOrDefaultAsync();

            if (account == null)
            {
                return false;
            }

            return true;
        }

        public async Task CreateAccount(Account account)
        {
            await _collection.InsertOneAsync(account);
        }
    }
}
