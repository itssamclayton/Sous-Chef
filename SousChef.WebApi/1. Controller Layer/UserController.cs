using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SousChef.WebApi._0._Models___DTOs;
using SousChef.WebApi._2._Service_Layer.Interfaces;
using SousChef.WebApi._3._Data_Access_Layer.Interfaces;

namespace SousChef.WebApi._1._Controller_Layer
{
    [Route("Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }
        [HttpPost]
        public async Task<string>CreateUserAsync(string userEmail, string password)
        {
            User newUserToCreate = new User(userEmail, password);
            User createdUser = await userService.CreateNewUserAsync(newUserToCreate);
            return createdUser.Email;
        }

        [HttpGet]
        public async Task<User>GetUserAsync(string userEmail)
        {
            return await userService.FindUserAsync(userEmail);
        }
    
    }
}
