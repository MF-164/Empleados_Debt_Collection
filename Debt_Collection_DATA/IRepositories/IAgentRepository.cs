using Debt_Collection_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_DATA.IRepositories
{
    public interface IAgentRepository
    {
        //Create
        Task CreateAsync(Agent newAgent);

        //Read
        Task<Agent> GetByIdAsync(int agentId);
        Task<IEnumerable<Agent>> GetByManagersAsync(IEnumerable<int> managers);
       
        //Update

        //Delete
    }
}
