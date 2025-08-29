using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debt_Collection_DATA.Models;

namespace Debt_Collection_DATA.IRepositories
{
    public interface IInvoiceRepository
    {
        Task<Invoice> CreateAsync(Invoice invoice);
        Task<Invoice> GetByIdAsync(int id);
        Task<IEnumerable<Invoice>> GetByClientIdAsync(int clientId);
        Task<IEnumerable<Invoice>> GetBySiteIdAsync(int siteId);
        Task<IEnumerable<Invoice>> GetByMonthAsync(int month, int year);
        Task<IEnumerable<Invoice>> GetByDateRangeAsync(DateTime start, DateTime end);
        Task UpdateAsync(Invoice updatedInvoice);
        Task UpdateApprovalStatusAsync(int invoiceId, string newStatus);
        Task UpdateInvoiceStatusAsync(int invoiceId, string newStatus);
        Task UpdatePaymentAsync(int invoiceId, decimal amount, DateTime paidDate);

    }

}
