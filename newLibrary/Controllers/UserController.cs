/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;*/
using Microsoft.AspNetCore.Mvc;
using newLibrary.Data;
using newLibrary.Helpers;
using newLibrary.Models.Entities;
using newLibrary.Models.UserDto;
using newLibrary.Services;

namespace Perpustakaan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly newLibraryDbContext dbContext;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddUserDto addUserDto, User userObj)
        {
            var user = await _userService.AddAndUpdateUser(userObj);

            if (user == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof (Post), Post);
        }

        //[HttpPost("authenticate")]
        //public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        //{
        //    var response = await _userService.Authenticate(model);
        //    if (response == null)
        //    {
        //        return BadRequest(new { message = "Username or password is incorrect" });
        //        return Ok(response);
        //    }

        //    /*{
        //        username = addUserDto.username,
        //        password = addUserDto.password,
        //        role = addUserDto.role
        //    };
        //    dbContext.Users.Add(newUser);
        //    dbContext.SaveChanges();
        //    return CreatedAtAction(nameof(AddUser), AddUser);*/
        //}

        [HttpGet]
        public IActionResult AllUser()
        {
            return Ok(dbContext.Users.ToList());
        }

        [HttpGet("Id/{Id_user}")]
        public IActionResult GetUser(Guid Id_user)
        {
            var user = dbContext.Users.Find(Id_user);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{Id_user}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] User userObj)
        {
            return Ok(await _userService.AddAndUpdateUser(userObj));
        }
        /*public IActionResult UpdateUser(Guid Id_user, UpdateUserDto updateUserDto)
        {
            var user = dbContext.Users.Find(Id_user);
            if (user == null)
            {
                return NotFound();
            }

            user.username = updateUserDto.username;
            user.password = updateUserDto.password;
            user.role = updateUserDto.role;
            dbContext.SaveChanges();
            return Ok();
        }*/

       
        [HttpDelete]
        public IActionResult DeleteUser(Guid Id_user)
        {
            var user = dbContext.Users.Find(Id_user);
            if(user == null)
            {
                return BadRequest();
            }
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
