using Debt_Collection_CORE.IServices;
using Debt_Collection_CORE.ViewModels;
using Debt_Collection_DATA.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Debt_Collection_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _service;

        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InvoiceVM>> GetById(int id)
        {
            var vm = await _service.GetByIdAsync(id);
            if (vm == null) return NotFound();
            return Ok(vm);
        }

        [HttpGet("by-month")]
        public async Task<ActionResult<IEnumerable<InvoiceVM>>> GetByMonth([FromQuery] int month, [FromQuery] int year, [FromQuery] int? clientId, [FromQuery] int? siteId)
        {
            var list = await _service.GetByMonthAsync(month, year, clientId, siteId);
            return Ok(list);
        }

        [HttpGet("by-range")]
        public async Task<ActionResult<IEnumerable<InvoiceVM>>> GetByRange([FromQuery] DateTime start, [FromQuery] DateTime end, [FromQuery] int? clientId, [FromQuery] int? siteId)
        {
            // Recommend ISO format yyyy-MM-dd when calling this endpoint
            if (start > end) return BadRequest("Start date must be before end date.");
            var list = await _service.GetByDateRangeAsync(start, end, clientId, siteId);
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceVM>> Create([FromBody] InvoiceVM vm)
        {
            var created = await _service.CreateAsync(vm);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InvoiceVM vm)
        {
            if (vm.Id <= 0) return BadRequest("Id must be greater than zero.");
            await _service.UpdateAsync(vm);
            return NoContent();
        }
    }
}
