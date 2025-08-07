using AutoMapper;
using Debt_Collection_CORE.IServices;
using Debt_Collection_CORE.ViewModels;
using Debt_Collection_DATA.IRepositories;
using Debt_Collection_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debt_Collection_CORE.Services
{
    public class MonthlyWorkReportService : IMonthlyWorkReportService
    {
        private readonly IMonthlyWorkReportRepository _repository;
        private readonly IMapper _mapper;

        public MonthlyWorkReportService(IMonthlyWorkReportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MonthlyWorkReportVM> CreateAsync(MonthlyWorkReportVM reportVM)
        {
            var entity = _mapper.Map<MonthlyWorkReport>(reportVM);
            var created = await _repository.CreateAsync(entity);
            return _mapper.Map<MonthlyWorkReportVM>(created);
        }

        public async Task<MonthlyWorkReportVM> GetByIdAsync(int id)
        {
            var report = await _repository.GetByIdAsync(id);
            return _mapper.Map<MonthlyWorkReportVM>(report);
        }

        public async Task<IEnumerable<MonthlyWorkReportVM>> GetByClientIdAsync(int clientId)
        {
            var reports = await _repository.GetByClientIdAsync(clientId);
            return reports.Select(_mapper.Map<MonthlyWorkReportVM>);
        }

        public async Task<IEnumerable<MonthlyWorkReportVM>> GetBySiteIdAsync(int siteId)
        {
            var reports = await _repository.GetBySiteIdAsync(siteId);
            return reports.Select(_mapper.Map<MonthlyWorkReportVM>);
        }

        public async Task<IEnumerable<MonthlyWorkReportVM>> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            var reports = await _repository.GetByDateRangeAsync(start, end);
            return reports.Select(_mapper.Map<MonthlyWorkReportVM>);
        }

        public async Task<IEnumerable<MonthlyWorkReportVM>> GetByMonthAsync(int month, int year)
        {
            var reports = await _repository.GetByMonthAsync(month, year);
            return reports.Select(_mapper.Map<MonthlyWorkReportVM>);
        }


        public async Task UpdateAsync(MonthlyWorkReportVM updatedReport)
        {
            var entity = _mapper.Map<MonthlyWorkReport>(updatedReport);
            await _repository.UpdateAsync(entity);
        }
    }

}
