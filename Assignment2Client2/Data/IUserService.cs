using System.Threading.Tasks;

namespace Assignment2Client2.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string username, string password);
    }
}