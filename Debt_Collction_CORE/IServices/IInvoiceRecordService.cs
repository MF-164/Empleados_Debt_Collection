using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debt_Collection_CORE.ViewModels.Debt_Collection_CORE.ViewModels;
using Debt_Collection_DATA.Models;

namespace Debt_Collection_CORE.IServices
{
    public interface IInvoiceRecordService
    {
        Task<InvoiceRecordVM> CreateAsync(InvoiceRecordVM invoice);
        Task<InvoiceRecordVM> GetByIdAsync(int id);
        Task<IEnumerable<InvoiceRecordVM>> GetBySiteIdAsync(int siteId);
        Task<IEnumerable<InvoiceRecordVM>> GetAllActiveAsync();
        Task UpdateAsync(InvoiceRecordVM invoice);
    }

}
