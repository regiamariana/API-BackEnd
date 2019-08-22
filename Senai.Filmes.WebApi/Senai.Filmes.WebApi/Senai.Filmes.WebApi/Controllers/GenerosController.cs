using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        List<GeneroDomains> estilos = new List<GeneroDomains>
        {
            new GeneroDomains { IdGenero = 1, Nome = "Romance" },
            new GeneroDomains { IdGenero = 2, Nome = "Terror" },
            new GeneroDomains { IdGenero = 3, Nome = "Ação" }
        };

        //colocar método

        GeneroRepository GeneroRepository = new GeneroRepository();

        [HttpGet]
        public IEnumerable<GeneroDomains> ListarTodos()
        {
            //return estilos;
            return GeneroRepository.Listar();
        }

        // o controller devera receber o id que eu quero buscar
        // GET /api/estilos/3
        //BUSCAGEM!!!!!!!!!!!
        //importante especificar no get o id
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            //chamar o método lá do repositório::::::::::
            GeneroDomains generoDomains = GeneroRepository.BuscarPorId(id);
            if (generoDomains == null)
                return NotFound();
            return Ok(generoDomains);
        }

        // cadastrar um novo
        [HttpPost]
        public IActionResult Cadastrar(GeneroDomains generoDomains)
        {
            GeneroRepository.Cadastrar(generoDomains);
            return Ok();
        }


        // DELETE /api/estilos/1009
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            GeneroRepository.Deletar(id);
            return Ok();
        }


    }
}
