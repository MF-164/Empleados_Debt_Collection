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

        public async Task<Agent> GetByIdAsync(int agentId)
        {
            try
            {
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
                return await _context.Agents
                    .Include(a => a.Clients)
                        .ThenInclude(c => c.Sites)
                    .FirstOrDefaultAsync(a => a.Id == agentId);
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAgentByIdAsync (AgentRepository): {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Agent>> GetAllActiveAsync()
        {
            try
            {
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
#pragma warning disable CS8629 // Nullable value type may be null.
                return await _context.Agents
                    .Include(a => a.Clients)
                        .ThenInclude(c => c.Sites)
                    .Where(a => (bool)a.IsActive)
                    .ToListAsync();
#pragma warning restore CS8629 // Nullable value type may be null.
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllActiveAgentsAsync (AgentRepository): {ex.Message}", ex);
            }
        }


        public async Task<Agent> CreateAsync(Agent newAgent)
        {
            try
            {
                var entry = await _context.Agents.AddAsync(newAgent);
                await _context.SaveChangesAsync();
                return entry.Entity; // Return the created entity with its generated ID
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in CreateAgentAsync method, Class: AgentRepository. Original error: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(Agent updatedAgent)
        {
            var existingAgent = await _context.Agents.FindAsync(updatedAgent.Id);
            if (existingAgent == null)
                throw new KeyNotFoundException("Agent not found.");

            PatchHelper.CopyAllFieldsExceptId(updatedAgent, existingAgent);

            await _context.SaveChangesAsync();
        }
    }
}
