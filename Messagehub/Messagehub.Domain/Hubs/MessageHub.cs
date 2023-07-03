using Messagehub.Domain.DTOs.Response;
using Messagehub.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace Messagehub.Domain.Hubs
{
    public class MessageHub : Hub
    {
        private readonly IAccountRepository _accountRepository;
        public static List<AccountResponseDTO> Users { get; set; }
        public static List<Message> Messages { get; set; }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "ChatHub");
            await Clients.Caller.SendAsync("UserConnected");

            await Clients.All.SendAsync("UsersOnline", Users);
        }


        public MessageHub(IAccountRepository accountRepository)
        {
            if (Users == null)
            {
                Users = new List<AccountResponseDTO>();
            }

            if (Messages == null)
            {
                Messages = new List<Message>();
            }

            _accountRepository = accountRepository;
        }

        public async Task<string> AddUserOnline(string email)
        {
            var account = await _accountRepository.GetAccountByEmail(email);
            var idConnection = Context.ConnectionId;

            var accountResponse = new AccountResponseDTO(idConnection, account.Username, account.Age, account.Email);
            Users.Add(accountResponse);

            await Clients.All.SendAsync("UsersOnline", Users);

            return idConnection;
        }

        public async Task<IEnumerable<AccountResponseDTO>> ShowUsers()
        {
            return Users;
        }

        private string GetPrivateGroupName(string from, string to)
        {
            var stringCompare = string.CompareOrdinal(from, to) < 0;
            return stringCompare ? $"{from}-{to}" : $"{to}-{from}";
        }

        public async Task SendToUser(string fromUser, string message, string toUser)
        {
            string privateGroupName = GetPrivateGroupName(fromUser, toUser);

            await Clients.Group(privateGroupName).SendAsync("NewPrivateMessage", new Message
            {
                FromUser = Users.Where(x => x.Id == fromUser).FirstOrDefault().Username,
                ToUser = Users.Where(x => x.Id == toUser).FirstOrDefault().Username,
                Msg = message
            });
        }

        public async Task CreatePrivateChat(string fromUser, string message, string toUser)
        {
            string privateGroupName = GetPrivateGroupName(fromUser, toUser);
            await Groups.AddToGroupAsync(Context.ConnectionId, privateGroupName);
            var toConnectionId = Users.Where(x => x.Id == toUser).FirstOrDefault()?.Id;
            await Groups.AddToGroupAsync(toConnectionId, privateGroupName);
        }

        public async Task RecivePrivateMessage(MessageDto message)
        {
        }

        public async Task<IEnumerable<Message>> ShowMessages()
        {
            return Messages;
        }

        public string GetConnectionId() => Context.ConnectionId;
    }

    public class MessageDto
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
    }

    public class Message
    {
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public string Msg { get; set; }
    }
}
