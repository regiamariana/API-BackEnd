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
    public class CategoriaController : ControllerBase
    {
        private ICategoriaRepository categoriaRepository { get; set; }

        public CategoriaController()
        {
            categoriaRepository = new CategoriaRepository();
        }
        [Authorize(Roles = "ADM")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(categoriaRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
           
                Categoria categoria = categoriaRepository.BuscarPorId(id);
                if (categoria == null)
                    return NotFound();
                return Ok(categoria);
           
                
           
        }
        
        [HttpPost]
        public IActionResult Cadastrar(Categoria categoria)
        {
            try
            {
                categoriaRepository.Cadastrar(categoria);
                return Ok();
                
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            categoriaRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(Categoria categoria)
        {
            try
            {
                Categoria CategoriaBuscada = categoriaRepository.BuscarPorId(categoria.Idcategoria);
                if (CategoriaBuscada == null)
                    return NotFound();
                categoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Ah, não. By - Pedro." });
            }
        }
    }
}