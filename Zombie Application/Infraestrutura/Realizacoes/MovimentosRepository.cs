using Core.Entidades;
using Infraestrutura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Infraestrutura.Realizacoes
{
    public class MovimentosRepository : Repository<Movimento>, IMovimentosRepository
    {
        public MovimentosRepository(DbContext Context) : base(Context)
        {
        }

        public Movimento GetLastMovement(Recurso recurso)
        {
            return this.Context.Set<Movimento>()
                .Include(m => m.Recurso)
                .Where(m => m.RecursoId == recurso.Id)
                .ToList()
                .OrderByDescending(m => m.Id)
                .FirstOrDefault();
        }

        public IEnumerable<Movimento> GetLastMovements()
        {
            var movimentosIds = this.Context.Set<Movimento>()
                .GroupBy(m => m.RecursoId, (key, m) => m.Max(m2 => m2.Id));

            var movimentos = this.Context.Set<Movimento>().Where(m => movimentosIds.Contains(m.Id));

            return movimentos.ToList();
        }

        public IEnumerable<Movimento> GetMovements(Recurso recurso)
        {
            return this.Context.Set<Movimento>()
                .Include(m => m.Recurso)
                .Include(m => m.Responsavel)
                .Where(m => m.RecursoId == recurso.Id)
                .ToList()
                .OrderBy(m => m.Data);
        }
    }
}
