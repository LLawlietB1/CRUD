namespace crud.Communication.Responses;

public class ResponseReadUser
{
    public Guid id { get; set; } = Guid.Empty;
    public string name { get; set; } = string.Empty;
    public string username { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;

}
