using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_SPmedicals_webapi.Domains;
using senai_SPmedicals_webapi.Interfaces;
using senai_SPmedicals_webapi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPmedicals_webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultumController : ControllerBase
    {
        private IConsultumRepository _consultumRepository { get; set; }

        public ConsultumController()
        {
            _consultumRepository = new ConsultumRepository();
        }

        [HttpGet("listar")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultumRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //[HttpGet("listar")]
        //public IActionResult ListConsultas()
        //{
        //    try
        //    {
        //        List<Consultum> consulta = _consultumRepository.ListConsultas();
        //        return Ok(consulta);
        //    }
        //    catch (Exception erro)
        //    {
        //        return BadRequest(erro);
        //    }
        //}

        [Authorize(Roles = "1")]
        [HttpPost("cadastro")]
        public IActionResult cadastrar(Consultum cons)
        {
            try
            {
                cons.IdClientes = Convert.ToByte(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);


                _consultumRepository.Cadastrar(cons);

                return StatusCode(201);

            }
            catch (Exception error)
            {

                return BadRequest(new
                {
                    mensagem = "Não é possivel cadastrar uma consulta se você não estiver logado, logue e tente novamente",
                    error
                });
            }
        }
    }
}
