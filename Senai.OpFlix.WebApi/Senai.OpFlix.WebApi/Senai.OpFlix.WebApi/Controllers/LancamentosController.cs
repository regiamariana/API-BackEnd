using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private ILancamentosRepository lancamentosRepository { get; set; }

        public LancamentosController()
        {
            lancamentosRepository = new LancamentosRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(lancamentosRepository.Listar());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
           
                Lancamentos lancamentoBuscado = lancamentosRepository.BuscarPorId(id);
                if (lancamentoBuscado == null)
                    return NotFound();
                return Ok(lancamentoBuscado);
           
        }

        //[Authorize(Roles = "ADM")]
        [HttpPost]
        public IActionResult Cadastrar(Lancamentos lancamentos)
        {
            try
           {
               lancamentosRepository.Cadastrar(lancamentos);
               return Ok(lancamentos);
           }
            catch (Exception ex)
            {

           return BadRequest(new { mensagem = "Eita, erro: " + ex.Message });
           }

            //try
            //{
            //    int Idlancamentos = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
            //    lancamentos.Idlancamentos = Idlancamentos;
            //    lancamentos.Datalancamento = DateTime.Now;
               
            //    lancamentosRepository.Cadastrar(lancamentos);
            //    return Ok();
            //}
            //catch (System.Exception ex)
            //{
            //    return BadRequest(new { mensagem = ex.Message });
            //}
        }

        [Authorize(Roles = "ADM")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Lancamentos lancamentos)
        {
            try
            {
                Lancamentos lancamentoBuscado = lancamentosRepository.BuscarPorId(lancamentos.Idlancamentos);
                if (lancamentoBuscado == null)
                    return NotFound();
                lancamentosRepository.Atualizar(lancamentos);
                return Ok();
            }
            catch (Exception ex )
            {

                return BadRequest(new { mensagem = "Ah, não. By - Pedro." });
            }
            
        }

        [Authorize(Roles = "ADM")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            lancamentosRepository.Deletar(id);
            return Ok();
        }
    }
}