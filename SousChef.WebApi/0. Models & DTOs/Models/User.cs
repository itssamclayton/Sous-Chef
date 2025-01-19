using System;
using System.Security.Cryptography;
using System.Text;
using SousChef.WebApi._2._Service_Layer.Helpers;
using System.ComponentModel.DataAnnotations;
using SousChef.WebApi._2._Service_Layer.Helpers;

namespace SousChef.WebApi._0._Models___DTOs;

public class User
{
    [Key]
    public Guid UserId {get; set;} // Primary key
    public string Email {get; set;}
    public string? HashedPassword {get; private set;}
    public string? FirstName {get; set;} = "";
    public string? LastName {get; set;} = "";
    public UserType UserType {get; set;} = UserType.Normal;
    public DietaryRestriction DietaryRestrictions {get; set;} = DietaryRestriction.None;
    
    // Navigation property
    public List<MealPlan>? MealPlans {get; set;} = new();
    public User() {}
    public User(string email, string password)
    {
        UserId = Guid.NewGuid();
        Email = email;
        HashedPassword = PasswordHelper.HashPassword(password);
        UserType = UserType.Normal;
    }


    public User(string email, string password, string userType)
    {
        UserId = Guid.NewGuid();
        Email = email;
        HashedPassword = PasswordHelper.HashPassword(password);
        UserType = UserHelper.ConvertToUserType(userType);
    }

    
   /* public void SetPassword(string password)
    {
        Salt = GenerateSalt();
        HashedPassword = HashPassword(password + Salt + Pepper);
    }

    public string GenerateSalt()
    {
        using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
        {
            byte[] saltBytes = new byte[32]; // creates a byte array of 32 bytes, which will hold the random data generated
            randomNumberGenerator.GetBytes(saltBytes); // fills the saltBytes array with random bytes from the RandomNumberGenerator
            return Convert.ToBase64String(saltBytes); // converts the random bytes into a Base64 string, which makes it safe to store in a text-based format like a database
        }
    }

    private string HashPassword(string password)
    {
        using(var sha256 = SHA256.Create())
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = sha256.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
*/

}
