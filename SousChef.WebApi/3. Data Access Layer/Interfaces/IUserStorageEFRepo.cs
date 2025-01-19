using System;
using SousChef.WebApi._0._Models___DTOs;

namespace SousChef.WebApi._3._Data_Access_Layer.Interfaces;

public interface IUserStorageEFRepo
{
    public Task<User> CreateNewUserInDbAsync(User userToCreateFromService);
    public Task<User> RetrieveUserFromDbAsync(string userEmailToRetrieve);


}
