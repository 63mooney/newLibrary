using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using newLibrary.Models.Entities;
using Azure.Messaging;

namespace newLibrary.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User?)context.HttpContext.Items["user"];
            if (user != null)
            {
                context.Result = new JsonResult(new { message = "Unauthorization" })
                { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
