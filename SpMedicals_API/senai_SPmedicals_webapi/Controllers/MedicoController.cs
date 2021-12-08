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
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _MedicoRepository {get; set;}

        public MedicoController()
        {
            _MedicoRepository = new MedicoRepository();
        }

        [HttpGet("BuscarId")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                return Ok(_MedicoRepository.BuscarporId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("listarMed")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_MedicoRepository.Lista());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
