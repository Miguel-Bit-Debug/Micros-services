namespace Gateway.Domain.DTOs.Request;

public class EventhubMessageRequestDTO
{
    public EventhubMessageRequestDTO(string eventName,
                              object detail)
    {
        EventName = eventName;
        Detail = detail;
    }

    public string EventName { get; private set; }
    public object Detail { get; private set; }
}
