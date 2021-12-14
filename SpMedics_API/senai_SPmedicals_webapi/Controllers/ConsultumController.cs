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
        [HttpGet("BuscarId")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                return Ok(_consultumRepository.buscarporId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost("cadastro")]
        public IActionResult cadastrar(Consultum novaConsulta)
        {
            try
            {
                _consultumRepository.Cadastrar(novaConsulta);

                return StatusCode(201);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Consultum ConsultaAtt)
        {
            try
            {
                _consultumRepository.Atualizar(id, ConsultaAtt);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int IdConsulta)
        {
            try
            {
                _consultumRepository.Deletar(IdConsulta);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("minhas")]
        public IActionResult minhasCons()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(_consultumRepository.ListarMinhas(IdUsuario));                    
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as presenças se o usuário não estiver logado!",
                    erro = error
                }) ; 
            }
        }

    }
}
