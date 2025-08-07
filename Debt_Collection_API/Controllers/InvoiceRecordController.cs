using Debt_Collection_CORE.IServices;
using Debt_Collection_CORE.ViewModels;
using Debt_Collection_CORE.ViewModels.Debt_Collection_CORE.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Debt_Collection_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceRecordController : ControllerBase
    {
        private readonly IInvoiceRecordService _service;

        public InvoiceRecordController(IInvoiceRecordService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceRecordVM>>> GetAllActive()
        {
            return Ok(await _service.GetAllActiveAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceRecordVM>> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet("by-site/{siteId}")]
        public async Task<ActionResult<IEnumerable<InvoiceRecordVM>>> GetBySiteId(int siteId)
        {
            return Ok(await _service.GetBySiteIdAsync(siteId));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] InvoiceRecordVM invoice)
        {
            var created = await _service.CreateAsync(invoice);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] InvoiceRecordVM invoice)
        {
            await _service.UpdateAsync(invoice);
            return NoContent();
        }
    }
}
