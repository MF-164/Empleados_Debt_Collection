using Debt_Collection_CORE.ViewModels;
using Debt_Collection_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_CORE.IServices
{
    public interface ISiteService
    {
        // Create
        Task<SiteVM> CreateAsync(SiteVM newSite);

        // Read
        Task<SiteVM> GetByIdAsync(int siteId);
        Task<IEnumerable<SiteVM>> GetByClientIdAsync(int clientId);
        Task<IEnumerable<SiteVM>> GetAllActiveAsync();

        // Update
        Task UpdateAsync(SiteVM updatedSite);
    }
}
