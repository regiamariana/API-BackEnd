using Microsoft.EntityFrameworkCore;
using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class ArtistaRepository
    {
        // listar
        public List<Artistas> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                // return ctx.Eventos.ToList();
                return ctx.Artistas.Include(x => x.IdEstiloNavigation).ToList();
            }
        }
    }
}
