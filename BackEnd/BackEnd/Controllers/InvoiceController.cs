using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using BackEnd.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        
        public InvoiceController(IInvoiceService invoice)
        {
            _invoiceService = invoice;
        }

        // GET: api/<InvoiceController>

        [Route("GetListInvoice")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> GetListInvoice()
        {

            try
            {
                var listInvoice = await _invoiceService.GetListInvoice();
                return Ok(listInvoice);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = "Errorrrr" });
            };
        }

        // GET api/<InvoiceController>/5
        [Route("GetListInvoiceById")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{idInvoice}")]
        public async Task<IActionResult> GetListInvoiceById(int idInvoice)
        {
            try
            {

                var listInvoice = await _invoiceService.GetListInvoiceById(idInvoice);
                return Ok(listInvoice);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<InvoiceController>/5

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{idInvoice}")]
        public async Task<IActionResult> Delete(int idInvoice)
        {

            try
            {
                var invoiceVal = await _invoiceService.ValidateInvoice(idInvoice);

                if (invoiceVal == null)
                    return BadRequest( new {message="No se encontro una Factura con el ID =>"+ idInvoice });

                await _invoiceService.deleteInvoice(invoiceVal);

                return Ok(new { message = "Se elimino correctamente la Factura con el ID =>" + idInvoice });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody]Invoice invoice)
        {

            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int IdUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                invoice.UserId = IdUsuario;
                invoice.DateReg = DateTime.Now;

                await _invoiceService.SaveInvoice(invoice); 

                return Ok(new { message = "Se creo correctamente la factura" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [Route("UpdateInvoice")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{idInvoice}")]
        public async Task<IActionResult> put(int idInvoice, [FromBody] Invoice invoice)
        {
            try
            {
                var invoiceVal = await _invoiceService.ValidateInvoice(idInvoice);

                if (invoiceVal == null)
                    return BadRequest(new { message = "No se encontro una Factura con el ID =>" + idInvoice });


                invoiceVal.IdCli = invoice.IdCli;
                invoiceVal.NameCli = invoice.NameCli;

                await _invoiceService.updateInvoice(invoiceVal);

                return Ok(new { message = "Se actualizo correctamente la Factura con el ID =>" + idInvoice });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


    }
}
