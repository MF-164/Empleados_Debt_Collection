using Debt_Collection_CORE.IServices;
using Debt_Collection_CORE.Services;
using Debt_Collection_CORE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Debt_Collection_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly ISiteService _siteService;

        public SiteController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        // GET: api/Site
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SiteVM>>> GetAllActive()
        {
            var sites = await _siteService.GetAllActiveAsync();
            return Ok(sites);
        }

        // GET: api/Site/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SiteVM>> GetById(int id)
        {
            var site = await _siteService.GetByIdAsync(id);
            if (site == null)
                return NotFound();

            return Ok(site);
        }

        // GET: api/Site/by-client/{clientId}
        [HttpGet("by-client/{clientId}")]
        public async Task<ActionResult<IEnumerable<ClientVM>>> GetByClientId(int clientId)
        {
            if (clientId <= 0)
                return BadRequest("Invalid client ID.");

            var sites = await _siteService.GetByClientIdAsync(clientId);
            return Ok(sites);
        }

        // POST: api/Site
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SiteVM newSite)
        {
            var createdSite = await _siteService.CreateAsync(newSite);
            return CreatedAtAction(nameof(GetById), new { id = createdSite.Id }, createdSite);
        }

        // PUT: api/Site
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] SiteVM updatedSite)
        {
            await _siteService.UpdateAsync(updatedSite);
            return NoContent();
        }
    }
}
