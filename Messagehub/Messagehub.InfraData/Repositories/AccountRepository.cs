using Messagehub.Domain.Interfaces.Repositories;
using Messagehub.Domain.Models;
using Messagehub.InfraData.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messagehub.InfraData.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMongoCollection<Account> _collection;

        public AccountRepository(IMongoDbContext context)
        {
            _collection = context.Collection<Account>();
        }
        public Task<Account> GetAccountByEmail(string email)
        {
            return _collection.Find(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
