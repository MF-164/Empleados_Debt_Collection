using AutoMapper;
using Debt_Collection_CORE.IServices;
using Debt_Collection_CORE.ViewModels;
using Debt_Collection_DATA.IRepositories;
using Debt_Collection_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debt_Collection_CORE.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            this._clientRepository = clientRepository;
            this._mapper = mapper;
        }

        public async Task CreateAsync(ClientVM newClient)
        {
            try
            {
                ValidateClient(newClient);
                await _clientRepository.CreateAsync(ConvertToClient(newClient));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in CreateAsync method, Class: ClientService, Project: Debt_Collection_CORE. Original error: {ex.Message}", ex);
            }
        }

        public async Task<Client> GetByIdAsync(int clientId)
        {
            try
            {
                if (clientId <= 0)
                {
                    throw new ArgumentException("Invalid client ID");
                }
                return await _clientRepository.GetByIdAsync(clientId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByIdAsync method, Class: ClientService, Project: Debt_Collection_CORE. Original error: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<ClientVM>> GetByAgentIdAsync(int agentId)
        {
            try
            {
                if (agentId <= 0)
                {
                    throw new ArgumentException("Invalid agent ID");
                }

                var clients = await _clientRepository.GetByAgentIdAsync(agentId);
                return clients.Select(c => ConvertToClientVM(c)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByAgentIdAsync method, Class: ClientService, Project: Debt_Collection_CORE. Original error: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<ClientVM>> GetAllActiveAsync()
        {
            try
            {
                var clients = await _clientRepository.GetAllActiveAsync();
                return clients.Select(c => ConvertToClientVM(c)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllAsync method, Class: ClientService, Project: Debt_Collection_CORE. Original error: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(ClientVM updatedClient)
        {
            try
            {
                ValidateClient(updatedClient);
                await _clientRepository.UpdateAsync(ConvertToClient(updatedClient));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in UpdateAsync method, Class: ClientService, Project: Debt_Collection_CORE. Original error: {ex.Message}", ex);
            }
        }

        private void ValidateClient(ClientVM client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            // Implement additional validations as necessary
            if (string.IsNullOrWhiteSpace(client.Name))
            {
                throw new ArgumentException("Client name cannot be empty");
            }

            // Add other validations as needed
        }

        private Client ConvertToClient(ClientVM clientVM) => _mapper.Map<Client>(clientVM);
        private ClientVM ConvertToClientVM(Client client) => _mapper.Map<ClientVM>(client);
    }
}
