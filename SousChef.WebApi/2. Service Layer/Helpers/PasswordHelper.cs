using System;
using Konscious.Security.Cryptography;
using DotNetEnv;

namespace SousChef.WebApi._2._Service_Layer.Helpers;

public class PasswordHelper
{
    
    public static string HashPassword(string password)
    {
    
    // Get the pepper from environment variable
    string pepper = Environment.GetEnvironmentVariable("PEPPER");

    // Generate salt using Argon2 (this is handled internally by Argon2 when using Argon2id)
    using (var argon2 = new Argon2id(System.Text.Encoding.UTF8.GetBytes(password + pepper)))
        {
            argon2.DegreeOfParallelism = 8; // Number of threads
            argon2.MemorySize = 65536;      // Memory usage in KB (64MB)
            argon2.Iterations = 4;          // Iteration count

            // Get the hashed result (salt + hashed password)
            byte[] hashBytes = argon2.GetBytes(32); // Adjust byte size for your needs (e.g., 32 bytes)
            
            // Base64 encode the hash result
            string hashedPassword = Convert.ToBase64String(hashBytes);
            
            // Return the final hash which includes the salt internally
            return hashedPassword;
        }
    }

    public static bool VerifyPassword(string inputPassword, string storedHash)
    {
        // Retrieve the pepper from environment variable
        string pepper = Environment.GetEnvironmentVariable("PEPPER");

        // Decrypt the stored hash to get salt
        string[] parts = storedHash.Split('$');
        byte[] salt = Convert.FromBase64String(parts[2]);

        // Rehash input password with the same salt and pepper
        using (var argon2 = new Argon2id(System.Text.Encoding.UTF8.GetBytes(inputPassword + pepper)))
        {
            argon2.DegreeOfParallelism = 8;
            argon2.MemorySize = 65536;
            argon2.Iterations = 4;

            // Use the same salt in the new hash generation
            argon2.Salt = salt;

            byte[] inputHash = argon2.GetBytes(32);

            // Convert the hashed password into a base64 string and compare
            string inputHashedPassword = Convert.ToBase64String(inputHash);
            return inputHashedPassword == storedHash;
        }
    }
    }