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
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext Context) : base(Context)
        {
        }

        public Usuario GetByLogin(string login)
        {
            return this.Context.Set<Usuario>()
                .Where(u => u.Login == login)
                .FirstOrDefault();
        }
    }
}
