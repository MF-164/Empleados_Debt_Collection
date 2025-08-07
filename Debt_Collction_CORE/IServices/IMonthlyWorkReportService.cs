using Debt_Collection_CORE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_CORE.IServices
{
    public interface IMonthlyWorkReportService
    {
        Task<MonthlyWorkReportVM> CreateAsync(MonthlyWorkReportVM report);
        Task<MonthlyWorkReportVM> GetByIdAsync(int id);
        Task<IEnumerable<MonthlyWorkReportVM>> GetByClientIdAsync(int clientId);
        Task<IEnumerable<MonthlyWorkReportVM>> GetBySiteIdAsync(int siteId);
        Task<IEnumerable<MonthlyWorkReportVM>> GetByDateRangeAsync(DateTime start, DateTime end);
        Task<IEnumerable<MonthlyWorkReportVM>> GetByMonthAsync(int month, int year);
        Task UpdateAsync(MonthlyWorkReportVM updatedReport);
    }
}
