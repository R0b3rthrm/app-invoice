using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using BackEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usersys usersys)
        {

            try
            {
               var validateExistence = await _userService.ValidateExistence(usersys);

               if (validateExistence)
                 return BadRequest(new { message = "El usuario " + usersys.NameUser + " ya existe" });

                usersys.PassUser = Encrypt.EncryptPass(usersys.PassUser);

                await _userService.SaveUser(usersys);
                return Ok(new { message = "Usuario Registrado con exito" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}

