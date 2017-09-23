using Infraestrutura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entidades;

namespace Infraestrutura.Realizacoes
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Contexto contexto;

        public IRepository<Recurso> Recursos { get { return new Repository<Recurso>(contexto); } }

        public IUsuarioRepository Usuarios { get { return new UsuarioRepository(contexto); } }

        public IMovimentosRepository Movimentos { get { return new MovimentosRepository(contexto); } }

        public UnitOfWork(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public void SaveChanges()
        {
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.contexto.Dispose();
            }
        }
    }
}
