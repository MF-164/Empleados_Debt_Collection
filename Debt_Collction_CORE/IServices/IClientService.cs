using Debt_Collection_CORE.ViewModels;
using Debt_Collection_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_CORE.IServices
{
    public interface IClientService
    {
        // Create
        Task<ClientVM> CreateAsync(ClientVM newClient);

        // Read
        Task<ClientVM> GetByIdAsync(int clientId);
        Task<IEnumerable<ClientVM>> GetByAgentIdAsync(int agentId);
        Task<IEnumerable<ClientVM>> GetAllActiveAsync();

        // Update
        Task UpdateAsync(ClientVM updatedClient);
    }
}
