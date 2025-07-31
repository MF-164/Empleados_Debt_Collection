using Debt_Collection_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_DATA.IRepositories
{
    // CRUD operations for Site entity
    public interface ISiteRepository
    {
        // Create
        Task<Site> CreateAsync(Site newSite);

        // Read
        Task<Site> GetByIdAsync(int siteId);
        Task<IEnumerable<Site>> GetByClientIdAsync(int clientId);
        Task<IEnumerable<Site>> GetAllActiveAsync();

        // Update
        Task UpdateAsync(Site updatedSite);
    }

}
