using System;
using SousChef.WebApi._0._Models___DTOs;
using SousChef.WebApi._2._Service_Layer.Interfaces;
using SousChef.WebApi._3._Data_Access_Layer.Interfaces;

namespace SousChef.WebApi._2._Service_Layer;

public class UserService : IUserService
{
    private readonly IUserStorageEFRepo userStorageEFRepo;
    public UserService(IUserStorageEFRepo _userStorageEFRepo)
    {
        userStorageEFRepo = _userStorageEFRepo;
    }
    public async Task<User> CreateNewUserAsync(User userToCreateFromController)
    {
        return await userStorageEFRepo.CreateNewUserInDbAsync(userToCreateFromController);
    }

    public async Task<User> FindUserAsync(string userEmailToFind)
    {
        return await userStorageEFRepo.RetrieveUserFromDbAsync(userEmailToFind);
    }

}
