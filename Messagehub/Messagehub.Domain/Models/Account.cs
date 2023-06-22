namespace Messagehub.Domain.Models
{
    public class Account : Entity
    {
        public Account(string username,
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
    }
}
