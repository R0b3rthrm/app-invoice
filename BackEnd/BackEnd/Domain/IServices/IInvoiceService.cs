using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface IInvoiceService
    {
        Task SaveInvoice(Invoice invoice);
        Task<Invoice> GetListInvoiceById(int IdInvoice);
        Task<List<Invoice>> GetListInvoice();
        Task<Invoice> ValidateInvoice(int IdInvoice);
        Task deleteInvoice(Invoice invoice);
        Task updateInvoice(Invoice invoice);


    }
}
