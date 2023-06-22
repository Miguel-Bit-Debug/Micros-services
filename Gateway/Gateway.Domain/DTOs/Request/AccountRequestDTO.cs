namespace Gateway.Domain.DTOs.Request
{
    public class AccountRequestDTO
    {
        public AccountRequestDTO(
               string username,
               int age,
               string email,
               string password)
        {
            Username = username;
            Age = age;
            Email = email;
            Password = password;
        }

        public string Username { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; set; }

        public void HashPassword(string password)
        {
            Password = password;
        }
    }
}
