using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Interfaces
{
    public interface IMovimentosRepository : IRepository<Movimento>
    {
        Movimento GetLastMovement(Recurso recurso);
        IEnumerable<Movimento> GetMovements(Recurso recurso);
        IEnumerable<Movimento> GetLastMovements();

    }
}
