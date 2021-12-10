using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_SPmedicals_webapi.Interfaces;
using senai_SPmedicals_webapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPmedicals_webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _ClienteRepository { get; set; }

        public ClienteController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        [HttpGet("BuscarId")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                return Ok(_ClienteRepository.buscarporId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpGet("BuscarId")]
        public IActionResult BuscarUsuarioLog(int id)
        {
            try
            {
                return Ok(_ClienteRepository.buscarUsuarioLog(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
