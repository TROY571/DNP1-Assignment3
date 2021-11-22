using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2Client2.Data
{
    public class InMemoryUserService
    {
        private List<User> users;

        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    Username = "siyu",
                    Password = "12345",
                    Age = 21,
                    SecurityLevel = 5
                },
                new User
                {
                    Username = "baby",
                    Password = "67890",
                    Age = 1,
                    SecurityLevel = 2
                }
            }.ToList();
        }
        public async Task<User> ValidateUser(string username, string password)
        {
            User first = users.FirstOrDefault(user => user.Username.Equals(username) && user.Password.Equals(password));
            if (first != null)
            {
                return first;
            }

            throw new Exception("User not found");
        }
    }
    }