using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_autopecas_WebApi2.Domains;
using Senai_autopecas_WebApi2.Repositories;

namespace Senai_autopecas_WebApi2.Controllers
{
    [Route("api/[controller]")]
    [Produces ("application/json")]
    [ApiController]
    public class PecasController : ControllerBase
    {
        private IPecasRepository pecasRepository { get; set; }

        public PecasController()
        {
            pecasRepository = new PecasRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(pecasRepository.Listar());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Pecas pecas = pecasRepository.BuscarPorId(id);
            if (pecas == null)
                return NotFound();
            return Ok(pecas);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Pecas pecas)
        {
            try
            {
                pecasRepository.Cadastrar(pecas);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Pecas pecas)
        {
            try
            {
                Pecas PecasBuscadas = pecasRepository.BuscarPorId(pecas.Idpeca);
                if (PecasBuscadas == null)
                    return NotFound();
                pecasRepository.Atualizar(pecas);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            pecasRepository.Deletar(id);
            return Ok();
        }
    }
}