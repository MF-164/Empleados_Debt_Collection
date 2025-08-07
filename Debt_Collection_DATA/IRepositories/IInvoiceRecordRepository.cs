using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debt_Collection_DATA.Models;

namespace Debt_Collection_DATA.IRepositories
{
    public interface IInvoiceRecordRepository
    {
        Task<InvoiceRecord> CreateAsync(InvoiceRecord invoice);
        Task<InvoiceRecord> GetByIdAsync(int id);
        Task<IEnumerable<InvoiceRecord>> GetBySiteIdAsync(int siteId);
        Task<IEnumerable<InvoiceRecord>> GetAllActiveAsync();
        Task UpdateAsync(InvoiceRecord updatedInvoice);
    }
}
