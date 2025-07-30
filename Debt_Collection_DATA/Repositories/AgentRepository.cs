using Debt_Collection_DATA.IRepositories;
using Debt_Collection_DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_DATA.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private readonly ApplicationDbContext _context;

        public AgentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Agent>> GetAllActiveAsync()
        {
            try
            {
                return await _context.Agents
                    .Where(a => (bool)a.IsActive)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllActiveAgentsAsync method, Class: AgentRepository. Original error: {ex.Message}", ex);
            }
        }

        public async Task<Agent> GetByIdAsync(int agentId)
        {
            try
            {
                return await _context.Agents.FindAsync(agentId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAgentByIdAsync method, Class: AgentRepository. Original error: {ex.Message}", ex);
            }
        }

        public async Task CreateAsync(Agent newAgent)
        {
            try
            {
                await _context.Agents.AddAsync(newAgent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in CreateAgentAsync method, Class: AgentRepository. Original error: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(Agent updatedAgent, int agentId)
        {
            try
            {
                var agent = await _context.Agents.FindAsync(agentId);
                if (agent == null)
                {
                    throw new KeyNotFoundException("Agent not found.");
                }

                // עדכון פרטי הסוכן
                agent.Name = updatedAgent.Name;
                agent.Phone = updatedAgent.Phone;
                agent.Email = updatedAgent.Email;
                agent.IsActive = updatedAgent.IsActive;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in UpdateAgentAsync method, Class: AgentRepository. Original error: {ex.Message}", ex);
            }
        }
    }

}
