using Gateway.Domain.DTOs.Request;
using Gateway.Domain.DTOs.Response;
using Gateway.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace Gateway.Domain.ExternalServices
{
    public class EventHubExternalService<T> : BaseExternalService<T>, IEventHubExternalService<T> where T : class
    {
        public EventHubExternalService(IConfiguration configuration,
                                       HttpClient httpClient,
                                       ILogger<T> logger) : base(httpClient, logger)
        {
            BaseUrl = configuration["EvenhubUrl"]!;
        }
        public async Task<GenericResponseDTO> PublishAsync(string user, T message)
        {
            try
            {
                _logger.LogInformation("enviando evento para eventhub");
                var eventHubMessage = new EventhubMessageRequestDTO(message.GetType().Name, message);
                var messageSerialized = JsonConvert.SerializeObject(eventHubMessage);

                var request = new StringContent(messageSerialized, Encoding.UTF8, "application/json");

                await _httpClient.PostAsync($"{BaseUrl}/api/publish", request);

                var response = new GenericResponseDTO()
                {
                    Message = "Publish message success.",
                    Success = true
                };

                _logger.LogInformation($"sucesso ao publicar evento {eventHubMessage.EventName} - usuario {user} - Data de publicação {DateTime.UtcNow}");

                return response;
            }
            catch (Exception ex)
            {
                var response = new GenericResponseDTO()
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
