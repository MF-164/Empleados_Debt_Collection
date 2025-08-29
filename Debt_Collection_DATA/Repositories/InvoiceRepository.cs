using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debt_Collection_DATA.IRepositories;
using Debt_Collection_DATA.Models;
using Microsoft.EntityFrameworkCore;

namespace Debt_Collection_DATA.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> CreateAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice> GetByIdAsync(int id)
        {
            return await _context.Invoices
                .Include(i => i.Client)
                .Include(i => i.Site)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Invoice>> GetByClientIdAsync(int clientId)
        {
            return await _context.Invoices
                .Where(i => i.ClientId == clientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetBySiteIdAsync(int siteId)
        {
            return await _context.Invoices
                .Where(i => i.SiteId == siteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetByMonthAsync(int month, int year)
        {
            return await _context.Invoices
                .Where(i => i.Month == month && i.Year == year)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            return await _context.Invoices
                .Where(i => new DateTime(i.Year, i.Month, 1) >= start &&
                            new DateTime(i.Year, i.Month, 1) <= end)
                .ToListAsync();
        }

        public async Task UpdateAsync(Invoice updatedInvoice)
        {
            _context.Invoices.Update(updatedInvoice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateApprovalStatusAsync(int invoiceId, string newStatus)
        {
            var invoice = await _context.Invoices.FindAsync(invoiceId);
            if (invoice == null) return;

            invoice.ApprovalStatus = newStatus;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInvoiceStatusAsync(int invoiceId, string newStatus)
        {
            var invoice = await _context.Invoices.FindAsync(invoiceId);
            if (invoice == null) return;

            invoice.InvoiceStatus = newStatus;
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaymentAsync(int invoiceId, decimal amount, DateTime paidDate)
        {
            var invoice = await _context.Invoices.FindAsync(invoiceId);
            if (invoice == null) return;

            if (invoice.PaidAmount1 == null)
            {
                invoice.PaidAmount1 = amount;
                invoice.PaidDate1 = paidDate;
            }
            else if (invoice.PaidAmount2 == null)
            {
                invoice.PaidAmount2 = amount;
                invoice.PaidDate2 = paidDate;
            }
            else
            {
                throw new InvalidOperationException("Invoice already has two payments.");
            }

            await _context.SaveChangesAsync();
        }
    }
}
    

