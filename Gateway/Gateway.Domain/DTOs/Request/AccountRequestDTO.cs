namespace Gateway.Domain.DTOs.Request
{
    public class AccountRequestDTO
    {
        public AccountRequestDTO(
               string username,
               int age,
               string email,
               string password,
               string address,
               string zipCode)
        {
            Username = username;
            Age = age;
            Email = email;
            Password = password;
            Address = address;
            ZipCode = zipCode;
        }

        public string Username { get; private set; }
        public int Age { get; private set; }
        public string Address { get; private set; }
        public string ZipCode { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; set; }

        public void HashPassword(string password)
        {
            Password = password;
        }
    }
}
