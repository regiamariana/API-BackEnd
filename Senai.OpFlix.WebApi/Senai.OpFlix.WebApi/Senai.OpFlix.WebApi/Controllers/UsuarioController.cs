using System;
using System.Collections.Generic;
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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository usuarioRepository { get; set; }

        public UsuarioController()
        {
            usuarioRepository = new UsuarioRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(usuarioRepository.Listar());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            
                Usuario usuario = usuarioRepository.BuscarPorId(id);
                if (usuario == null)
                    return NotFound();
                return Ok(usuario);
           
        }

        [Authorize(Roles = "ADM")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                usuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Eita, erro: " + ex.Message });
            }
        }

        [Authorize(Roles = "ADM")]
        [HttpPut]
        public IActionResult Atualizar(Usuario usuario)
        {
            Usuario UsuarioBuscado = usuarioRepository.BuscarPorId(usuario.Idusuario);
            if (UsuarioBuscado == null)
                return NotFound();
            usuarioRepository.Atualizar(usuario);
            return Ok();
        }

        [Authorize(Roles = "ADM")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            usuarioRepository.Deletar(id);
            return Ok();
        }
    }
}