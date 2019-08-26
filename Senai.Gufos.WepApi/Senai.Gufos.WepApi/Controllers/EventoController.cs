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
    [Produces ("application/json")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        EventoRepository eventoRepository = new EventoRepository();

        [HttpPost]
        public IActionResult Cadastrar(Eventos evento)
        {
            try {
                eventoRepository.Cadastrar(evento)

            } catch {
            }

        }
    }
}