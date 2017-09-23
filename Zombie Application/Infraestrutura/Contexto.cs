using Core.Entidades;
using Infraestrutura.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura
{
    public class Contexto : DbContext
    {
        public DbSet<Recurso>  Recursos { get; set; }
        public DbSet<Movimento>  Movimentos { get; set; }
        public DbSet<Usuario>  Usuarios { get; set; }

        public Contexto() : base("name=DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new MovimentosMap());
            modelBuilder.Configurations.Add(new RecursosMap());
        }
    }
}
