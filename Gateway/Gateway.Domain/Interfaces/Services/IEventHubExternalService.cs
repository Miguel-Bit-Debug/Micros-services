using Gateway.Domain.DTOs.Response;

namespace Gateway.Domain.Interfaces.Services
{
    public interface IEventHubExternalService<T> where T : class
    {
        Task<GenericResponseDTO> PublishAsync(string user, T message);
    }
}
