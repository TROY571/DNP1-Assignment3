using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment2Client2.Data
{
    public interface IAdultService
    {
        Task<Adult> GetAsync(int id);
        Task<IList<Adult>> GetAdultsAsync();
        Task AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int adultId);
        Task UpdateAsync(Adult adult);
    }
}