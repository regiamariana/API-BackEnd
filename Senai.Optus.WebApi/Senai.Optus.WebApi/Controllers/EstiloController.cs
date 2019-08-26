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
            return Ok(estiloRepository.Listar());
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
    }
}






