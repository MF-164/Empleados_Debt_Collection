using Debt_Collection_DATA.IRepositories;
using Debt_Collection_DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debt_Collection_DATA.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Client> CreateAsync(Client newClient)
        {
            try
            {
                var entry = await _context.Clients.AddAsync(newClient);
                await _context.SaveChangesAsync();

#pragma warning disable CS8603 // Possible null reference return.
                return await _context.Clients
                    .Include(c => c.Agent)
                    .Include(c => c.Sites)
                    .FirstOrDefaultAsync(c => c.Id == entry.Entity.Id);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in CreateAsync (ClientRepository): {ex.Message}", ex);
            }
        }

        public async Task<Client> GetByIdAsync(int clientId)
        {
            try
            {
                var client = await _context.Clients
                    .Include(c => c.Agent)
                    .Include(c => c.Sites)
                    .FirstOrDefaultAsync(c => c.Id == clientId);

                if (client == null)
                    throw new KeyNotFoundException("Client not found.");

                return client;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByIdAsync (ClientRepository): {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Client>> GetByAgentIdAsync(int agentId)
        {
            try
            {
                return await _context.Clients
                    .Include(c => c.Agent)
                    .Include(c => c.Sites)
                    .Where(c => c.AgentId == agentId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByAgentIdAsync (ClientRepository): {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Client>> GetAllActiveAsync()
        {
            try
            {
                return await _context.Clients
                    .Include(c => c.Agent)
                    .Include(c => c.Sites)
                    .Where(c => c.IsActive == true)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllActiveAsync (ClientRepository): {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(Client updatedClient)
        {
            try
            {
                var existingClient = await _context.Clients.FindAsync(updatedClient.Id);
                if (existingClient == null)
                    throw new KeyNotFoundException("Client not found.");

                PatchHelper.CopyAllFieldsExceptId(updatedClient, existingClient);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in UpdateAsync (ClientRepository): {ex.Message}", ex);
            }
        }

    }
}
