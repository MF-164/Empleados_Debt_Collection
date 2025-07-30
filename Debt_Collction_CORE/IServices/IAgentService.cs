using Debt_Collection_CORE.ViewModels;
using Debt_Collection_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_CORE.IServices
{
    public interface IAgentService
    {
        // Create
        Task CreateAsync(AgentVM newAgent);

        // Read
        Task<IEnumerable<AgentVM>> GetAllActiveAsync();
        Task<Agent> GetByIdAsync(int agentId);

        // Update
        Task UpdateAsync(AgentVM updatedAgent, int agentId);
    }
}
