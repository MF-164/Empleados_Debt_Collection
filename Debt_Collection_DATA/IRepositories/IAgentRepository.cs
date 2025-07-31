using Debt_Collection_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_DATA.IRepositories
{
    // CRUD operations for Agent entity
    public interface IAgentRepository
    {
        // Create
        Task<Agent> CreateAsync(Agent newAgent);

        // Read
        Task<IEnumerable<Agent>> GetAllActiveAsync();
        Task<Agent> GetByIdAsync(int agentId);
        
        // Update
        Task UpdateAsync(Agent updatedAgent);
    }

}
