using Debt_Collection_CORE.IServices;
using Debt_Collection_CORE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Debt_Collection_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        // GET: api/Agent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgentVM>>> GetAllActive()
        {
            var agents = await _agentService.GetAllActiveAsync();
            return Ok(agents);
        }

        // GET: api/Agent/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AgentVM>> GetById(int id)
        {
            var agent = await _agentService.GetByIdAsync(id);
            if (agent == null)
                return NotFound();

            return Ok(agent);
        }

        // POST: api/Agent
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AgentVM newAgent)
        {
            var createdAgent = await _agentService.CreateAsync(newAgent);
            return CreatedAtAction(nameof(GetById), new { id = createdAgent.Id }, createdAgent);
        }

        // PUT: api/Agent
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] AgentVM updatedAgent)
        {
            await _agentService.UpdateAsync(updatedAgent);
            return NoContent();
        }
    }
}
