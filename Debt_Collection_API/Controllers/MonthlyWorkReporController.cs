using Debt_Collection_CORE.IServices;
using Debt_Collection_CORE.Services;
using Debt_Collection_CORE.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Debt_Collection_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyWorkReportController : ControllerBase
    {
        private readonly IMonthlyWorkReportService _monthlyWorkReportservice;

        public MonthlyWorkReportController(IMonthlyWorkReportService service)
        {
            _monthlyWorkReportservice = service;
        }

        // GET: api/MonthlyWorkReport/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MonthlyWorkReportVM>> GetById(int id)
        {
            var report = await _monthlyWorkReportservice.GetByIdAsync(id);
            if (report == null)
                return NotFound();

            return Ok(report);
        }

        // GET: api/MonthlyWorkReport/by-client/{clientId}
        [HttpGet("by-client/{clientId}")]
        public async Task<ActionResult<IEnumerable<MonthlyWorkReportVM>>> GetByClientId(int clientId)
        {
            var reports = await _monthlyWorkReportservice.GetByClientIdAsync(clientId);
            return Ok(reports);
        }

        // GET: api/MonthlyWorkReport/by-site/{siteId}
        [HttpGet("by-site/{siteId}")]
        public async Task<ActionResult<IEnumerable<MonthlyWorkReportVM>>> GetBySiteId(int siteId)
        {
            var reports = await _monthlyWorkReportservice.GetBySiteIdAsync(siteId);
            return Ok(reports);
        }

        // GET: api/MonthlyWorkReport/by-month?month=8&year=2025
        [HttpGet("by-month")]
        public async Task<ActionResult<IEnumerable<MonthlyWorkReportVM>>> GetByMonth([FromQuery] int month, [FromQuery] int year)
        {
            var reports = await _monthlyWorkReportservice.GetByMonthAsync(month, year);
            return Ok(reports);
        }

        // GET: api/MonthlyWorkReport/by-range?start=2025-06-01&end=2025-08-31
        [HttpGet("by-range")]
        public async Task<ActionResult<IEnumerable<MonthlyWorkReportVM>>> GetByDateRange([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            if (start > end)
                return BadRequest("Start date must be before end date.");

            var reports = await _monthlyWorkReportservice.GetByDateRangeAsync(start, end);
            return Ok(reports);
        }

        // POST: api/MonthlyWorkReport
        [HttpPost]
        public async Task<ActionResult<MonthlyWorkReportVM>> Create([FromBody] MonthlyWorkReportVM report)
        {
            var created = await _monthlyWorkReportservice.CreateAsync(report);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/MonthlyWorkReport
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MonthlyWorkReportVM updatedReport)
        {
            if (updatedReport.Id <= 0)
                return BadRequest("Id must be greater than zero.");

            await _monthlyWorkReportservice.UpdateAsync(updatedReport);
            return NoContent();
        }
    }
}
