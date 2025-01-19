using System;
using SousChef.WebApi._0._Models___DTOs;

namespace SousChef.WebApi._2._Service_Layer.Interfaces;

public interface IUserService
{
    public Task<User> CreateNewUserAsync(User userToCreateFromController);
    public Task<User> FindUserAsync(string userEmailToFind);


}
