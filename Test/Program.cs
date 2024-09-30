using BussinessObject;
using DataAccess;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test
{
    public class Program
    {
        public static List<Account> GetAccounts()
        {
            return new List<Account>
            {
                new Account
                {
                    Username = "user1",
                    Email = "user1@example.com",
                    PasswordHash = "hashed_password_1",
                    ProfilePictureUrl = "https://example.com/images/user1.jpg",
                    Bio = "This is user1's bio.",
                    Friends = new List<ObjectId> { ObjectId.GenerateNewId(), ObjectId.GenerateNewId() },
                    Followers = new List<ObjectId> { ObjectId.GenerateNewId() },
                    Following = new List<ObjectId> { ObjectId.GenerateNewId(), ObjectId.GenerateNewId() },
                    CreatedAt = DateTime.UtcNow
                },
                new Account
                {
                   
                    Username = "user2",
                    Email = "user2@example.com",
                    PasswordHash = "hashed_password_2",
                    ProfilePictureUrl = "https://example.com/images/user2.jpg",
                    Bio = "This is user2's bio.",
                    Friends = new List<ObjectId> { ObjectId.GenerateNewId() },
                    Followers = new List<ObjectId> { ObjectId.GenerateNewId(), ObjectId.GenerateNewId() },
                    Following = new List<ObjectId>(),
                    CreatedAt = DateTime.UtcNow
                },
                new Account
                {
                  
                    Username = "user3",
                    Email = "user3@example.com",
                    PasswordHash = "hashed_password_3",
                    ProfilePictureUrl = "https://example.com/images/user3.jpg",
                    Bio = "This is user3's bio.",
                    Friends = new List<ObjectId>(),
                    Followers = new List<ObjectId> { ObjectId.GenerateNewId() },
                    Following = new List<ObjectId> { ObjectId.GenerateNewId(), ObjectId.GenerateNewId(), ObjectId.GenerateNewId() },
                    CreatedAt = DateTime.UtcNow
                }
            };
        }

        static async Task Main(string[] args)
        {
            var accounts = GetAccounts();
            AccountDao accountDao = new AccountDao();

            foreach (var account in accounts)
            {
                await accountDao.CreateAsync(account);
            }

            Console.WriteLine("Accounts created successfully.");
        }
    }
}
