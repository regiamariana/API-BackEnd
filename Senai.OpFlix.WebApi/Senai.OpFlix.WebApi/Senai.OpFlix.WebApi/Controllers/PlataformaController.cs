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
    public class PlataformaController : ControllerBase
    {
        private IPlataformaRepository plataformaRepository { get; set; }

        public PlataformaController()
        {
            plataformaRepository = new PlataformaRepository();
        }


        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(plataformaRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Plataforma plataforma = plataformaRepository.BuscarPorId(id);
                if (plataforma == null)
                    return NotFound();
                return Ok(plataforma);
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Plataforma plataforma)
        {
            try
            {
                plataformaRepository.Cadastrar(plataforma);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Eita, erro: " + ex.Message });

            }
        }

        [HttpPut]
        public IActionResult Atualizar(Plataforma plataforma)
        {
            try
            {
                Plataforma Plataforma = plataformaRepository.BuscarPorId(plataforma.Idplataforma);
                if (Plataforma == null)
                    return NotFound();
                plataformaRepository.Atualizar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Eita, erro: " + ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            plataformaRepository.Deletar(id);
            return Ok();
        }
    }

}