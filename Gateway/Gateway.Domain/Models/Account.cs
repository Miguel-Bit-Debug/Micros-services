namespace Gateway.Domain.Models
{
    public class Account : Entity
    {
        public Account(string username,
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
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
