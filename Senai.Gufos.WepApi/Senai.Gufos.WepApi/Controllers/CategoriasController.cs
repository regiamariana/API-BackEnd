using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WepApi.Domains;
using Senai.Gufos.WepApi.Repository;

namespace Senai.Gufos.WepApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        CategoriaRepository categoriaRepository = new CategoriaRepository();
        [HttpGet]
        //IEnumerable
        public IActionResult Listar()
        {
            return Ok(categoriaRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            try
            {
                categoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(new { mensagem = "Eita, erro : " + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Categorias categorias = categoriaRepository.BuscarPorId(id);
            if (categorias == null)
                return NotFound();
            return Ok(categorias);

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            categoriaRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(Categorias categorias)
        {
            try
            {
                //pesquisar uma categoria
                Categorias categoriabuscada = categoriaRepository.BuscarPorId(categorias.IdCategorias);
                //caso n encontre, not found
                if (categoriabuscada == null)
                    return NotFound();
                //caso encontrada eu att pq quero
                categoriaRepository.Atualizar(categorias);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = "Anao vei" });
            }
        }
    }
}