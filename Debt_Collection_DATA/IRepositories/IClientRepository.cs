using Debt_Collection_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_DATA.IRepositories
{
    // CRUD operations for Client entity
    public interface IClientRepository
    {
        // Create
        Task CreateAsync(Client newClient);

        // Read
        Task<Client> GetByIdAsync(int clientId);
        Task<IEnumerable<Client>> GetByAgentIdAsync(int agentId);
        Task<IEnumerable<Client>> GetAllActiveAsync();

        // Update
        Task UpdateAsync(Client updatedClient);
    }

}
