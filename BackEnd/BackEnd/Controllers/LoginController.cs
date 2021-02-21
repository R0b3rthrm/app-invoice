using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using BackEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _config;

        public LoginController(ILoginService loginService, IConfiguration config)
        {
            _loginService = loginService;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usersys usersys)
        {
            try
            {
                usersys.PassUser = Encrypt.EncryptPass(usersys.PassUser);
                var user = await _loginService.ValidateUser(usersys);


                if (user == null)
                    return BadRequest(new { message = "Usuario o Contraseña Invalidos" });


                string tokenString = JwtConfigurator.GetToken(user, _config);
                return Ok(new { token = tokenString });
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

