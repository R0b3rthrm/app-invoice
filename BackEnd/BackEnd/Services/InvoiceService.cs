using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task deleteInvoice(Invoice invoice)
        {
           await _invoiceRepository.deleteInvoice(invoice);
        }

        public async Task<List<Invoice>> GetListInvoice()
        {
            return await _invoiceRepository.GetListInvoice();

        }

        public async Task<Invoice> GetListInvoiceById(int IdInvoice)
        {
            return await _invoiceRepository.GetListInvoiceById(IdInvoice);
        }

        public async  Task SaveInvoice(Invoice invoice)
        {
            await _invoiceRepository.SaveInvoice(invoice);
        }

        public async Task updateInvoice( Invoice invoice)
        {
            await _invoiceRepository.updateInvoice( invoice);
        }

        public async Task<Invoice> ValidateInvoice(int IdInvoice)
        {
            return await _invoiceRepository.ValidateInvoice(IdInvoice);
        }
    }
}
