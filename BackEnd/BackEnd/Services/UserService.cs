using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class UserService:IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task SaveUser(Usersys usersys) => await _userRepository.SaveUser(usersys);

        public async Task<bool> ValidateExistence(Usersys usersys) => await _userRepository.ValidateExistence(usersys);


    }
}
