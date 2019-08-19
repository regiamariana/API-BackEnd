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
    }
}
