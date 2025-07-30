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
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        // Dependency Injection
        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Client newClient)
        {
            try
            {
                await _context.Clients.AddAsync(newClient);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in CreateAsync method, Class: ClientRepository. Original error: {ex.Message}", ex);
            }
        }

        public async Task<Client> GetByIdAsync(int clientId)
        {
            try
            {
                var client = await _context.Clients.FindAsync(clientId);
                if (client == null)
                {
                    throw new KeyNotFoundException("Client not found.");
                }
                return client;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByIdAsync method, Class: ClientRepository. Original error: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Client>> GetByAgentIdAsync(int agentId)
        {
            try
            {
                return await _context.Clients
                    .Where(c => c.AgentId == agentId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByAgentIdAsync method, Class: ClientRepository. Original error: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Client>> GetAllActiveAsync()
        {
            try
            {
                return await _context.Clients
                    .Where(c => (bool)c.IsActive) // סינון לקוחות פעילים
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllAsync method, Class: ClientRepository. Original error: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(Client updatedClient)
        {
            try
            {
                var client = await _context.Clients.FindAsync(updatedClient.Id);
                if (client == null)
                {
                    throw new KeyNotFoundException("Client not found.");
                }

                // עדכון פרטי הלקוח
                client.Name = updatedClient.Name;
                client.Email = updatedClient.Email;
                client.Phone = updatedClient.Phone;
                client.AgentRate = updatedClient.AgentRate;
                client.AgentId = updatedClient.AgentId;
                client.InvoiceContact = updatedClient.InvoiceContact;
                client.RegularEmployeeRate = updatedClient.RegularEmployeeRate;
                client.PaysBreaks = updatedClient.PaysBreaks;
                client.PaymentForecast = updatedClient.PaymentForecast;
                client.IsActive = updatedClient.IsActive;
                client.ProfessionalEmployeeRate = updatedClient.ProfessionalEmployeeRate;


                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in UpdateAsync method, Class: ClientRepository. Original error: {ex.Message}", ex);
            }
        }
    }

}
