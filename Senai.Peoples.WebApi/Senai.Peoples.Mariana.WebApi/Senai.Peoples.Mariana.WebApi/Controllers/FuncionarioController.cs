using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.Mariana.WebApi.Domains;
using Senai.Peoples.Mariana.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.Mariana.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        FuncionarioRepository FuncionarioRepository = new FuncionarioRepository();

        //vamos encaixar os verbos agora
        
        [HttpGet]
        public IEnumerable<FuncionarioDomain> ListarTodos()
        {
            return FuncionarioRepository.Listar();
        }

        //ATENÇÃO
        //ESSES [HttpGet],  [HttpGet("{id}")] SERVEM PARA INDICAR AO HTTP QUAL É O VERBO
        //POIS ISSO QUE EM ![HttpGet("{id}")]! HÁ ("{id}"), POIS É NECESSÁRIO COLOCAR O ID NO endpoint
        //FIM

        // o controller devera receber o id que eu quero buscar
        // GET /api/estilos/3
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionarioDomain funcionarioDomain = FuncionarioRepository.BuscarPorId(id);
            if (funcionarioDomain == null)
                return NotFound();
            return Ok(funcionarioDomain);
        }

        // cadastrar um novo
        [HttpPost]
        public IActionResult Cadastrar(FuncionarioDomain FuncionarioDomain)
        {
            FuncionarioRepository.Cadastrar(FuncionarioDomain);
            return Ok();
        }

        // DELETE /api/estilos/1009
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            FuncionarioRepository.Deletar(id);
            return Ok();
        }

        // atualizar - update
        [HttpPut]
        public IActionResult Atualizar(FuncionarioDomain funcionarioDomain)
        {
            FuncionarioRepository.Atualizar(funcionarioDomain);
            return Ok();
        }

        //cadastrar datah
        [HttpPut("{datanascimento}")]
        public IActionResult CadastrarData(FuncionarioDomain funcionarioDomain)
        {
            FuncionarioRepository.CadastrarData(funcionarioDomain);
            return Ok();
        }

    }
}
