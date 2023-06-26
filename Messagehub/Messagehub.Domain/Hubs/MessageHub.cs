using Messagehub.Domain.DTOs.Response;
using Messagehub.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace Messagehub.Domain.Hubs
{
    public class MessageHub : Hub
    {
        private readonly IAccountRepository _accountRepository;
        public static List<AccountResponseDTO> Users { get; set; }


        public MessageHub(IAccountRepository accountRepository)
        {
            if (Users == null)
            {
                Users = new List<AccountResponseDTO>();
            }

            _accountRepository = accountRepository;
        }

        public async Task GetUser(string email)
        {
            var account = await _accountRepository.GetAccountByEmail(email);

            if (account != null)
            {
                var accountResponse = new AccountResponseDTO(account.Id, account.Username, account.Age, account.Email);
                Users.Add(accountResponse);
            }
        }

        public async Task<IEnumerable<AccountResponseDTO>> ShowUsers()
        {
            return Users;
        }

        public void SendMessage(string idConnection)
        {

        }
    }
}
