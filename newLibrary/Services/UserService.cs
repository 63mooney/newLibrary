using newLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using newLibrary.Helpers;
using newLibrary.Data;
using newLibrary.Models.Entities;

namespace newLibrary.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly newLibraryDbContext db;

        public IOptions<AppSettings> AppSettings { get; }

        public UserService(IOptions<AppSettings> appSettings, newLibraryDbContext _db)
        {
            _appSettings = appSettings.Value;
            db = _db;
           
        }

        public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
        {
            var user = await db.Users.SingleOrDefaultAsync(x => x.username == model.username && x.password == model.password);

            if (user == null) return null;
            var token = await generateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await db.Users.Where(x => x.isActive == true).ToListAsync();
        }

        public async Task<User?> GetById(Guid Id_user)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.Id_user == Id_user);
        }

        public async Task<User?> AddAndUpdateUser(User userObj)
        {
            bool isSuccess = false;
            if (userObj.Id_user == null)
            {
                var obj = await db.Users.FirstOrDefaultAsync(c => c.Id_user == userObj.Id_user);
                if (obj == null)
                {
                    obj.username = userObj.username;
                    obj.password = userObj.password;
                    obj.role = userObj.role;
                    db.Users.Update(obj);
                    isSuccess = await db.SaveChangesAsync() > 0;
                }
            }
            else
            {
                await db.Users.AddAsync(userObj);
                isSuccess = await db.SaveChangesAsync() > 0;
            }
            return isSuccess ? userObj : null;
        }

        private async Task<string> generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("Id_user", user.Id_user.ToString()) }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });
            return tokenHandler.WriteToken(token);
        }
    }
}
