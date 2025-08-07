using Debt_Collection_DATA.Helpers;
using Debt_Collection_DATA.IRepositories;
using Debt_Collection_DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debt_Collection_DATA.Repositories
{
    public class InvoiceRecordRepository : IInvoiceRecordRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InvoiceRecord> CreateAsync(InvoiceRecord invoice)
        {
            try
            {
                var entry = await _context.InvoiceRecords.AddAsync(invoice);
                await _context.SaveChangesAsync();

                var result = await _context.InvoiceRecords
                    .Include(i => i.Site)
                    .FirstOrDefaultAsync(i => i.Id == entry.Entity.Id);

                if (result == null)
                    throw new Exception("Invoice record was not found after creation.");

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in CreateAsync (InvoiceRecordRepository): {ex.Message}", ex);
            }
        }

        public async Task<InvoiceRecord> GetByIdAsync(int id)
        {
            try
            {
                var invoice = await _context.InvoiceRecords
                    .Include(i => i.Site)
                    .FirstOrDefaultAsync(i => i.Id == id);

                if (invoice == null)
                    throw new KeyNotFoundException("Invoice not found.");

                return invoice;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByIdAsync (InvoiceRecordRepository): {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<InvoiceRecord>> GetBySiteIdAsync(int siteId)
        {
            try
            {
                return await _context.InvoiceRecords
                    .Include(i => i.Site)
                    .Where(i => i.SiteId == siteId && i.IsActive)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetBySiteIdAsync (InvoiceRecordRepository): {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<InvoiceRecord>> GetAllActiveAsync()
        {
            try
            {
                return await _context.InvoiceRecords
                    .Include(i => i.Site)
                    .Where(i => i.IsActive)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllActiveAsync (InvoiceRecordRepository): {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(InvoiceRecord updatedInvoice)
        {
            try
            {
                var existing = await _context.InvoiceRecords.FindAsync(updatedInvoice.Id);
                if (existing == null)
                    throw new KeyNotFoundException("Invoice not found.");

                PatchHelper.PatchNonNullValues(updatedInvoice, existing, _context, "Id");
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in UpdateAsync (InvoiceRecordRepository): {ex.Message}", ex);
            }
        }
    }
}
