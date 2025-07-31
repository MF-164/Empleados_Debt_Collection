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
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientVM> CreateAsync(ClientVM newClient)
        {
            try
            {
                ValidateClient(newClient);
                var createdClient = await _clientRepository.CreateAsync(ConvertToClient(newClient));
                return ConvertToClientVM(createdClient);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in CreateAsync (ClientService): {ex.Message}", ex);
            }
        }

        public async Task<ClientVM> GetByIdAsync(int clientId)
        {
            if (clientId <= 0)
                throw new ArgumentException("Invalid client ID");

            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client == null)
                throw new KeyNotFoundException($"Client with id {clientId} not found");

            return ConvertToClientVM(client);
        }

        public async Task<IEnumerable<ClientVM>> GetByAgentIdAsync(int agentId)
        {
            if (agentId <= 0)
                throw new ArgumentException("Invalid agent ID");

            var clients = await _clientRepository.GetByAgentIdAsync(agentId);
            return clients.Select(ConvertToClientVM).ToList();
        }

        public async Task<IEnumerable<ClientVM>> GetAllActiveAsync()
        {
            var clients = await _clientRepository.GetAllActiveAsync();
            return clients.Select(ConvertToClientVM).ToList();
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
                throw new Exception($"Error in UpdateAsync (ClientService): {ex.Message}", ex);
            }
        }

        private void ValidateClient(ClientVM client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            if (string.IsNullOrWhiteSpace(client.Name))
                throw new ArgumentException("Client name cannot be empty");
        }

        private Client ConvertToClient(ClientVM clientVM) => _mapper.Map<Client>(clientVM);
        private ClientVM ConvertToClientVM(Client client) => _mapper.Map<ClientVM>(client);
    }
}
