using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Product.Domain.DTOs.Request;
using Product.Domain.DTOs.Response;
using Product.Domain.Interfaces;
using System.Text;

namespace Product.Domain.ExternalService
{
    public class EventHubExternalService<T> : BaseExternalService<T>, IEventHubExternalService<T> where T : class
    {
        public EventHubExternalService(IConfiguration configuration,
                                       HttpClient httpClient,
                                       ILogger<T> logger) : base(httpClient, logger)
        {
            BaseUrl = configuration["EventhubUrl"];
        }
        public async Task<EventhubMessageResponseDTO> PublishAsync(string user, T message)
        {
            try
            {
                _logger.LogInformation("enviando evento para eventhub");
                var eventHubMessage = new EventhubMessageRequestDTO(message.GetType().Name, user, message);
                var messageSerialized = JsonConvert.SerializeObject(eventHubMessage);
                var request = new StringContent(messageSerialized, Encoding.UTF8, "application/json");

                _httpClient.PostAsync($"{BaseUrl}/api/publish", request);

                var response = new EventhubMessageResponseDTO()
                {
                    Message = "Publish message success.",
                    Success = true
                };

                _logger.LogInformation($"sucesso ao publicar evento {eventHubMessage.EventName} - usuario {eventHubMessage.User} - Data de publicação {DateTime.UtcNow}");

                return response;
            }
            catch (Exception ex)
            {
                var response = new EventhubMessageResponseDTO()
                {
                    Message = $"Publish message failed - {ex.Message}",
                    Success = false
                };

                _logger.LogError($"Error publish message EventHub - {ex.Message}");

                return response;
            }
        }
    }
}
