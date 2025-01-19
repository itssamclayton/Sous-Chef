using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SousChef.WebApi._0._Models___DTOs;

namespace SousChef.WebApi._3._Data_Access_Layer.Interfaces;

public class UserStorageEFRepo : IUserStorageEFRepo
{
    private readonly SousChefDbContext sousChefDbContext;

        public UserStorageEFRepo(SousChefDbContext _sousChefDbContext)
        {
            sousChefDbContext = _sousChefDbContext;
        }
        
        public async Task<User> CreateNewUserInDbAsync(User userToCreateFromService)
        {
            await sousChefDbContext.Users.AddAsync(userToCreateFromService);
            await sousChefDbContext.SaveChangesAsync();
            return userToCreateFromService;
        }

        public async Task<User> RetrieveUserFromDbAsync(string userEmailToRetrieve)
        {
            try
            {
                User? FoundUser = await sousChefDbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmailToRetrieve);
                if (FoundUser != null | FoundUser.Email == userEmailToRetrieve)
                {
                    return FoundUser;
                }
                else
                {
                    throw new Exception("No user with that email address could be found in the database.");
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
}
