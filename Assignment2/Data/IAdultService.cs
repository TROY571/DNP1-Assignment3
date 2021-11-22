using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment2.Data
{
    public interface IAdultService
    {
        Task<IList<Adult>> GetAdultsAsync();
        Task<Adult> AddAdultAsync(Adult adult);

        Task RemoveAdultAsync(int adultId);
        Task<Adult> UpdateAsync(Adult adult);
    }
}