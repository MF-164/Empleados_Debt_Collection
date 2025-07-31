using AutoMapper;
using Debt_Collection_CORE.IServices;
using Debt_Collection_CORE.ViewModels;
using Debt_Collection_DATA.IRepositories;
using Debt_Collection_DATA.Models;
using Debt_Collection_DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debt_Collection_CORE.Services
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;

        public AgentService(IAgentRepository agentRepository, IMapper mapper)
        {
            this._agentRepository = agentRepository;
            this._mapper = mapper;
        }

        public async Task<AgentVM> CreateAsync(AgentVM newAgent)
        {
            try
            {
                ValidateAgent(newAgent);
                var createdAgent = await _agentRepository.CreateAsync(ConvertToAgent(newAgent));
                return ConvertToAgentVM(createdAgent);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in CreateAsync method, Class: AgentService, Project: Debt_Collection_CORE. Original error: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<AgentVM>> GetAllActiveAsync()
        {
            try
            {
                var agents = await _agentRepository.GetAllActiveAsync();
                return agents.Select(a => ConvertToAgentVM(a)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllActiveAsync method, Class: AgentService, Project: Debt_Collection_CORE. Original error: {ex.Message}", ex);
            }
        }

        public async Task<AgentVM> GetByIdAsync(int agentId)
        {
            try
            {
                if (agentId <= 0)
                {
                    throw new ArgumentException("Invalid agent ID");
                } 
                var agent = await _agentRepository.GetByIdAsync(agentId);
                return ConvertToAgentVM(agent);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByIdAsync method, Class: AgentService, Project: Debt_Collection_CORE. Original error: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(AgentVM updatedAgent)
        {
            try
            {
                ValidateAgent(updatedAgent);
                await _agentRepository.UpdateAsync(ConvertToAgent(updatedAgent));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in UpdateAsync method, Class: AgentService, Project: Debt_Collection_CORE. Original error: {ex.Message}", ex);
            }
        }

        private void ValidateAgent(AgentVM agent)
        {
            if (agent == null)
            {
                throw new ArgumentNullException(nameof(agent));
            }

            // Implement additional validations as necessary
            if (string.IsNullOrWhiteSpace(agent.Name))
            {
                throw new ArgumentException("Agent name cannot be empty");
            }

            // Add other validations as needed
        }

        private Agent ConvertToAgent(AgentVM agentVM) => _mapper.Map<Agent>(agentVM);
        private AgentVM ConvertToAgentVM(Agent agent) => _mapper.Map<AgentVM>(agent);
    }
}
