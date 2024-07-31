using newLibrary.Models.Entities;

namespace newLibrary.Helpers
{
    public class AuthenticateResponse
    {
        public Guid Id_user { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id_user = user.Id_user;
            username = user.username;
            password = user.password;
            role = user.role;
            Token = token;
        }
    }
}
