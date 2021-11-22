using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data;

namespace Assignment2.Data
{
    public class InMemoryUserService:IUserService
    {
        private ICollection<User> users;

        public InMemoryUserService()
        {
            users = new List<User>();
            users.Add(new User
            {
                Username = "siyu",
                Password = "12345",
                Age = 21,
                SecurityLevel = 5
            });
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