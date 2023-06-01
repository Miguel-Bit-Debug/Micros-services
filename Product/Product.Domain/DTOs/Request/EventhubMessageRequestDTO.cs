namespace Product.Domain.DTOs.Request;

public class EventhubMessageRequestDTO
{
    public EventhubMessageRequestDTO(string eventName,
                              string user,
                              object detail)
    {
        EventName = eventName;
        User = user;
        Detail = detail;
    }

    public string EventName { get; private set; }
    public string User { get; private set; }
    public object Detail { get; private set; }
}
