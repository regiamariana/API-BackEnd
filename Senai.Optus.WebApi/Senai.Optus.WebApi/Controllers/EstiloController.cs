using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstiloController : ControllerBase
    {
        // repositorio
        EstiloRepository estiloRepository = new EstiloRepository();
        // endpoints
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(estiloRepository.Listar());
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        public IActionResult Cadastrar(Estilos estilos)
        {
            try
            {
                estiloRepository.Cadastrar(estilos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "MEEEHH ERRO" + ex.Message });
            }
        }

        //COLOCAR AUTHORIZE AQUI [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estilos estilos = estiloRepository.BuscarPorId(id);
            if (estilos == null)
                return NotFound();
            return Ok(estilos);
        }

        [HttpPut]
        public IActionResult Atualizar(Estilos estilos)
        {
            try
            {
                // pesquisar uma categoria
                Estilos EstiloBuscado = estiloRepository.BuscarPorId(estilos.IdEstilo);
                // caso nao encontre, not found
                if (EstiloBuscado == null)
                    return NotFound();
                // caso contrario, se ela for encontrada, eu atualizo pq quero
                estiloRepository.Atualizar(estilos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "erroh. penah." });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            estiloRepository.Deletar(id);
            return Ok();
        }
    }
}






