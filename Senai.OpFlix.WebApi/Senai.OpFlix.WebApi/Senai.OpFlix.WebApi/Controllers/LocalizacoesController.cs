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
    public class LocalizacoesController : ControllerBase
    {
        public ILocalizacoesRepository LocalizacoesRepository { get; set; }

        public LocalizacoesController()
        {
            LocalizacoesRepository = new LocalizacoesRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Localizacoes localizacoes)
        {
            try
            {
                LocalizacoesRepository.Cadastrar(localizacoes);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(new { Mensagem = e.Message });
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LocalizacoesRepository.Listar());
        }
    }
}