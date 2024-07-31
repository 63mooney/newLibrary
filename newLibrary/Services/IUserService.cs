using newLibrary.Helpers;
using newLibrary.Models.Entities;

namespace newLibrary.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetById(Guid Id_user);
        Task<User?> AddAndUpdateUser(User userObj);
    }



}
