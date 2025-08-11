using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Debt_Collection_CORE.IServices;
using Debt_Collection_CORE.ViewModels.Debt_Collection_CORE.ViewModels;
using Debt_Collection_DATA.IRepositories;
using Debt_Collection_DATA.Models;

namespace Debt_Collection_CORE.Services
{
    public class InvoiceRecordService : IInvoiceRecordService
    {
        private readonly IInvoiceRecordRepository _repo;
        private readonly IMapper _mapper;

        public InvoiceRecordService(IInvoiceRecordRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<InvoiceRecordVM> CreateAsync(InvoiceRecordVM invoiceVM)
        {
            var invoice = _mapper.Map<InvoiceRecord>(invoiceVM);
            var created = await _repo.CreateAsync(invoice);
            return _mapper.Map<InvoiceRecordVM>(created);
        }

        public async Task<InvoiceRecordVM> GetByIdAsync(int id)
        {
            var invoice = await _repo.GetByIdAsync(id);
            return _mapper.Map<InvoiceRecordVM>(invoice);
        }

        public async Task<IEnumerable<InvoiceRecordVM>> GetBySiteIdAsync(int siteId)
        {
            var invoices = await _repo.GetBySiteIdAsync(siteId);
            return invoices.Select(_mapper.Map<InvoiceRecordVM>).ToList();
        }

        public async Task<IEnumerable<InvoiceRecordVM>> GetAllActiveAsync()
        {
            var invoices = await _repo.GetAllActiveAsync();
            return invoices.Select(_mapper.Map<InvoiceRecordVM>).ToList();
        }

        public async Task UpdateAsync(InvoiceRecordVM invoiceVM)
        {
            var invoice = _mapper.Map<InvoiceRecord>(invoiceVM);
            await _repo.UpdateAsync(invoice);
        }
    }

}
