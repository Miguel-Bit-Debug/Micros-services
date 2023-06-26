namespace Messagehub.Domain.DTOs.Response
{
    public class AccountResponseDTO
    {
        public AccountResponseDTO(string id,
                                  string username,
                                  int age,
                                  string email)
        {
            Id = id;
            Username = username;
            Age = age;
            Email = email;
        }

        public string Id { get; private set; }
        public string Username { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
    }
}
