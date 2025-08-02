using System.ComponentModel.DataAnnotations;

namespace crud.Communication.Requests;

public class RequestDeleteUser
{
    [Required]
    public Guid id { get; set; } = Guid.Empty;
    public string email { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
}
