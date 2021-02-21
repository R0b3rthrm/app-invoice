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
    public class LoginRepository: ILoginRepository
    {
        private ApplicationDbContext _context;

        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usersys> ValidateUser(Usersys usersys)
        {
            var userVal = await _context.Usersys.Where(x => x.NameUser == usersys.NameUser && x.PassUser == usersys.PassUser).FirstOrDefaultAsync();
            return userVal;

        }
    }
}
