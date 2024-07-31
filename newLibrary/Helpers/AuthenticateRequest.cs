using System.ComponentModel;
using System.Globalization;
namespace newLibrary.Helpers
{
    public class AuthenticateRequest
    {
        [DefaultValue("System")]
        public required string username { get; set; }

        [DefaultValue("System")]
        public required string password { get; set; }
    }
}
