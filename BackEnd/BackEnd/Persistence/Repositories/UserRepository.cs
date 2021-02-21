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
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveUser(Usersys usersys)
        {
            _context.Add(usersys);
            await _context.SaveChangesAsync();

        }



        public async Task<bool> ValidateExistence(Usersys usersys)
        {
            var validateExistence = await _context.Usersys.AnyAsync(x => x.NameUser == usersys.NameUser);
            return validateExistence;
        }
    }
}
