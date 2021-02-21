using BackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Usersys> Usersys { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Invoice_Detail> Invoice_Detail { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
