namespace crud.Communication.Requests
{
    public class RequestCreateUser
    {
        public string name { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string confirmPassword { get; set; } = string.Empty;

    }
}
