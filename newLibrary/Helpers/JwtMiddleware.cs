﻿using newLibrary.Models;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using newLibrary.Services;

namespace newLibrary.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate _next, IOptions<AppSettings> appSettings)
        {
            _next = _next;
            _appSettings = appSettings.Value;
        }

        public AppSettings AppSettings => _appSettings;

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();
            if (token != null)
            {
                await attachUserToContext(context, userService, token);
                await _next(context);
            }
        }

        private async Task attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var Id_user = Guid.Parse(jwtToken.Claims.First(x => x.Type == "Id_user").Value);

                context.Items["User"] = await userService.GetById(Id_user);
            }
            catch
            {

            }
        }
    }
}
