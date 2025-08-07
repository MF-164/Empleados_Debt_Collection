using Debt_Collection_DATA.Models;
using Debt_Collection_DATA.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debt_Collection_DATA.Repositories
{
    public class MonthlyWorkReportRepository : IMonthlyWorkReportRepository
    {
        private readonly ApplicationDbContext _context;

        public MonthlyWorkReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MonthlyWorkReport> CreateAsync(MonthlyWorkReport report)
        {
            var entry = await _context.MonthlyWorkReports.AddAsync(report);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<MonthlyWorkReport> GetByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.MonthlyWorkReports
                .Include(r => r.Client)
                .Include(r => r.Site)
                .FirstOrDefaultAsync(r => r.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<MonthlyWorkReport>> GetByClientIdAsync(int clientId)
        {
            return await _context.MonthlyWorkReports
                .Where(r => r.ClientId == clientId)
                .Include(r => r.Site)
                .ToListAsync();
        }

        public async Task<IEnumerable<MonthlyWorkReport>> GetBySiteIdAsync(int siteId)
        {
            return await _context.MonthlyWorkReports
                .Where(r => r.SiteId == siteId)
                .Include(r => r.Client)
                .ToListAsync();
        }

        public async Task<IEnumerable<MonthlyWorkReport>> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            int startIndex = start.Year * 12 + start.Month;
            int endIndex = end.Year * 12 + end.Month;

            return await _context.MonthlyWorkReports
                .Where(r => (r.Year * 12 + r.Month) >= startIndex && (r.Year * 12 + r.Month) <= endIndex)
                .Include(r => r.Client)
                .Include(r => r.Site)
                .ToListAsync();
        }


        public async Task<IEnumerable<MonthlyWorkReport>> GetByMonthAsync(int month, int year)
        {
            return await _context.MonthlyWorkReports
                .Where(r => r.Month == month && r.Year == year)
                .Include(r => r.Client)
                .Include(r => r.Site)
                .ToListAsync();
        }

        public async Task UpdateAsync(MonthlyWorkReport updatedReport)
        {
            var existing = await _context.MonthlyWorkReports.FindAsync(updatedReport.Id);
            if (existing == null)
                throw new KeyNotFoundException("MonthlyWorkReport not found.");

            PatchHelper.CopyAllFieldsExceptId(updatedReport, existing);

            await _context.SaveChangesAsync();
        }
    }

}
