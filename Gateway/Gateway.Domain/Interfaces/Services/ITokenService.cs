namespace Gateway.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(string username, string email);
    }
}
