using System.Threading.Tasks;

namespace Assignment2.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string username, string password);
    }
}