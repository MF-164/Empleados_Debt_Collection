using Debt_Collection_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_DATA.IRepositories
{
    public interface IMonthlyWorkReportRepository
    {
        Task<MonthlyWorkReport> CreateAsync(MonthlyWorkReport report);
        Task<MonthlyWorkReport> GetByIdAsync(int id);
        Task<IEnumerable<MonthlyWorkReport>> GetByClientIdAsync(int clientId);
        Task<IEnumerable<MonthlyWorkReport>> GetBySiteIdAsync(int siteId);
        Task<IEnumerable<MonthlyWorkReport>> GetByDateRangeAsync(DateTime start, DateTime end);
        Task<IEnumerable<MonthlyWorkReport>> GetByMonthAsync(int month, int year);
        Task UpdateAsync(MonthlyWorkReport updatedReport);
    }

}
