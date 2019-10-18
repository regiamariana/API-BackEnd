using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_autopecas_WebApi2.Domains;
using Senai_autopecas_WebApi2.Interfaces;
using Senai_autopecas_WebApi2.Repositories;

namespace Senai_autopecas_WebApi2.Controllers
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

            Usuarios usuario = usuarioRepository.BuscarPorId(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);

        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
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

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Usuarios usuario)
        {
            Usuarios UsuarioBuscado = usuarioRepository.BuscarPorId(usuario.Idusuario);
            if (UsuarioBuscado == null)
                return NotFound();
            usuarioRepository.Atualizar(usuario);
            return Ok();
        }

        //[Authorize(Roles = "ADMINISTRADOR")]
        //[HttpDelete("{id}")]
        //public IActionResult Deletar(int id)
        //{
        //    usuarioRepository.Deletar(id);
        //    return Ok();
        //}
    }
}