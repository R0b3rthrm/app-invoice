using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IRepositories
{
    public interface IInvoiceRepository
    {
        Task SaveInvoice(Invoice invoice);
        Task<Invoice> GetListInvoiceById(int IdInvoice);
        Task<List<Invoice>> GetListInvoice();

        Task<Invoice> ValidateInvoice(int IdInvoice);

        Task updateInvoice(Invoice invoice);
        Task deleteInvoice(Invoice invoice);
    }
}
