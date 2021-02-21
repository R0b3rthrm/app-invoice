using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface IUserService
    {
        Task SaveUser(Usersys user);
        Task<bool> ValidateExistence(Usersys usersys);
    }
}
