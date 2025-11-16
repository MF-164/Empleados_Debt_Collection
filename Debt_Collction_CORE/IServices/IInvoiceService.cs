using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Debt_Collection_CORE.ViewModels;

namespace Debt_Collection_CORE.IServices
{
    public interface IInvoiceService
    {
        Task<InvoiceVM> CreateAsync(InvoiceVM invoice);
        Task<InvoiceVM> GetByIdAsync(int id);
        Task<IEnumerable<InvoiceVM>> GetByClientIdAsync(int clientId);
        Task<IEnumerable<InvoiceVM>> GetBySiteIdAsync(int siteId);
        Task<IEnumerable<InvoiceVM>> GetByMonthAsync(int month, int year);
        Task<IEnumerable<InvoiceVM>> GetByDateRangeAsync(DateTime start, DateTime end);
        Task UpdateAsync(InvoiceVM updatedInvoice);

        // Business-specific updates
        Task UpdateApprovalStatusAsync(int invoiceId, string newStatus);
        Task UpdateInvoiceStatusAsync(int invoiceId, string newStatus);
        Task UpdatePaymentAsync(int invoiceId, decimal amount, DateTime paidDate);
    }
}
