using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(lancamentosRepository.Listar());
        }


        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
           
                Lancamentos lancamentoBuscado = lancamentosRepository.BuscarPorId(id);
                if (lancamentoBuscado == null)
                    return NotFound();
                return Ok();
           
        }


        [HttpPost]
        public IActionResult Cadastrar(Lancamentos lancamentos)
        {
            try
            {
                lancamentosRepository.Cadastrar(lancamentos);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Eita, erro: " + ex.Message });
            }
        }


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


        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            lancamentosRepository.Deletar(id);
            return Ok();
        }
    }
}