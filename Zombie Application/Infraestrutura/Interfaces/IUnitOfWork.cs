using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Recurso> Recursos { get; }
        IUsuarioRepository Usuarios { get; }
        IMovimentosRepository Movimentos { get; }
        void SaveChanges();
    }
}
