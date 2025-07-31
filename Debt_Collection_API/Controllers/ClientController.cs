using Debt_Collection_CORE.IServices;
using Debt_Collection_CORE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Debt_Collection_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientVM>>> GetAllActive()
        {
            var clients = await _clientService.GetAllActiveAsync();
            return Ok(clients);
        }

        // GET: api/Client/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientVM>> GetById(int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        // GET: api/Client/by-agent/{agentId}
        [HttpGet("by-agent/{agentId}")]
        public async Task<ActionResult<IEnumerable<ClientVM>>> GetByAgentId(int agentId)
        {
            if (agentId <= 0)
                return BadRequest("Invalid agent ID.");

            var clients = await _clientService.GetByAgentIdAsync(agentId);
            return Ok(clients);
        }

        // POST: api/Client
        [HttpPost]
        public async Task<ActionResult<ClientVM>> Create([FromBody] ClientVM newClient)
        {
            var createdClient = await _clientService.CreateAsync(newClient);
            return CreatedAtAction(nameof(GetById), new { id = createdClient.Id }, createdClient);
        }

        // PUT: api/Client
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ClientVM updatedClient)
        {
            await _clientService.UpdateAsync(updatedClient);
            return NoContent();
        }
    }
}
