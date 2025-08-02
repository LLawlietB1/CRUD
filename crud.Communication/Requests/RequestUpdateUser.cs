namespace crud.Communication.Requests;

public class RequestUpdateUser
{
    public Guid id { get; set; } = Guid.Empty;
    public string name { get; set; } = string.Empty;
    public string username { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
    public string confirmPassword { get; set; } = string.Empty;
}
