using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Debt_Collection_CORE.IServices;
using Debt_Collection_CORE.ViewModels;

namespace Debt_Collection_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceVM>> Create([FromBody] InvoiceVM invoice)
        {
            var created = await _invoiceService.CreateAsync(invoice);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceVM>> GetById(int id)
        {
            var invoice = await _invoiceService.GetByIdAsync(id);
            if (invoice == null) return NotFound();
            return Ok(invoice);
        }

        [HttpGet("by-client/{clientId}")]
        public async Task<ActionResult<IEnumerable<InvoiceVM>>> GetByClientId(int clientId)
        {
            var invoices = await _invoiceService.GetByClientIdAsync(clientId);
            return Ok(invoices);
        }

        [HttpGet("by-site/{siteId}")]
        public async Task<ActionResult<IEnumerable<InvoiceVM>>> GetBySiteId(int siteId)
        {
            var invoices = await _invoiceService.GetBySiteIdAsync(siteId);
            return Ok(invoices);
        }

        [HttpGet("by-month")]
        public async Task<ActionResult<IEnumerable<InvoiceVM>>> GetByMonth([FromQuery] int month, [FromQuery] int year)
        {
            var invoices = await _invoiceService.GetByMonthAsync(month, year);
            return Ok(invoices);
        }

        [HttpGet("by-date-range")]
        public async Task<ActionResult<IEnumerable<InvoiceVM>>> GetByDateRange([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var invoices = await _invoiceService.GetByDateRangeAsync(start, end);
            return Ok(invoices);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InvoiceVM invoice)
        {
            await _invoiceService.UpdateAsync(invoice);
            return NoContent();
        }

        [HttpPatch("{id}/approval-status")]
        public async Task<IActionResult> UpdateApprovalStatus(int id, [FromQuery] string status)
        {
            await _invoiceService.UpdateApprovalStatusAsync(id, status);
            return NoContent();
        }

        [HttpPatch("{id}/invoice-status")]
        public async Task<IActionResult> UpdateInvoiceStatus(int id, [FromQuery] string status)
        {
            await _invoiceService.UpdateInvoiceStatusAsync(id, status);
            return NoContent();
        }

        [HttpPatch("{id}/payment")]
        public async Task<IActionResult> UpdatePayment(int id, [FromQuery] decimal amount, [FromQuery] DateTime paidDate)
        {
            await _invoiceService.UpdatePaymentAsync(id, amount, paidDate);
            return NoContent();
        }
    }
}
