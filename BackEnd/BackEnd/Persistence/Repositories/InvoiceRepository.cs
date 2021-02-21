using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task deleteInvoice(Invoice invoice)
        {
         //   _context.Entry(invoice).State = EntityState.Modified

            _context.Remove(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Invoice>> GetListInvoice()
        {
            return await _context.Invoice.Include(x => x.Invoice_Detail).ToListAsync(); 
        }

        public async Task<Invoice> GetListInvoiceById(int IdInvoice)
        {
            return await _context.Invoice.Where(x => x.Id == IdInvoice).Include(x=> x.Invoice_Detail).FirstOrDefaultAsync();
        }

        public async Task SaveInvoice(Invoice invoice)
        {
            _context.Add(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task updateInvoice(Invoice invoice)
        {
            //_context.Entry(invoice).State = EntityState.Modified;
            _context.Update(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task<Invoice> ValidateInvoice(int IdInvoice)
        {
            return await _context.Invoice.Where(x => x.Id == IdInvoice).FirstOrDefaultAsync();
        }


    }
}
