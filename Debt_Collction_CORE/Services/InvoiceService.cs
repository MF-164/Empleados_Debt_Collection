using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Debt_Collection_CORE.IServices;
using Debt_Collection_CORE.ViewModels;
using Debt_Collection_DATA.IRepositories;
using Debt_Collection_DATA.Models;

namespace Debt_Collection_CORE.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<InvoiceVM> CreateAsync(InvoiceVM invoiceVM)
        {
            var invoice = _mapper.Map<Invoice>(invoiceVM);
            var createdInvoice = await _invoiceRepository.CreateAsync(invoice);
            return _mapper.Map<InvoiceVM>(createdInvoice);
        }

        public async Task<InvoiceVM> GetByIdAsync(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            return invoice != null ? _mapper.Map<InvoiceVM>(invoice) : null;
        }

        public async Task<IEnumerable<InvoiceVM>> GetByClientIdAsync(int clientId)
        {
            var invoices = await _invoiceRepository.GetByClientIdAsync(clientId);
            return _mapper.Map<IEnumerable<InvoiceVM>>(invoices);
        }

        public async Task<IEnumerable<InvoiceVM>> GetBySiteIdAsync(int siteId)
        {
            var invoices = await _invoiceRepository.GetBySiteIdAsync(siteId);
            return _mapper.Map<IEnumerable<InvoiceVM>>(invoices);
        }

        public async Task<IEnumerable<InvoiceVM>> GetByMonthAsync(int month, int year)
        {
            var invoices = await _invoiceRepository.GetByMonthAsync(month, year);
            return _mapper.Map<IEnumerable<InvoiceVM>>(invoices);
        }

        public async Task<IEnumerable<InvoiceVM>> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            var invoices = await _invoiceRepository.GetByDateRangeAsync(start, end);
            return _mapper.Map<IEnumerable<InvoiceVM>>(invoices);
        }

        public async Task UpdateAsync(InvoiceVM updatedInvoiceVM)
        {
            var updatedInvoice = _mapper.Map<Invoice>(updatedInvoiceVM);
            await _invoiceRepository.UpdateAsync(updatedInvoice);
        }

        public async Task UpdateApprovalStatusAsync(int invoiceId, string newStatus)
        {
            await _invoiceRepository.UpdateApprovalStatusAsync(invoiceId, newStatus);
        }

        public async Task UpdateInvoiceStatusAsync(int invoiceId, string newStatus)
        {
            await _invoiceRepository.UpdateInvoiceStatusAsync(invoiceId, newStatus);
        }

        public async Task UpdatePaymentAsync(int invoiceId, decimal amount, DateTime paidDate)
        {
            await _invoiceRepository.UpdatePaymentAsync(invoiceId, amount, paidDate);
        }
    }
}
