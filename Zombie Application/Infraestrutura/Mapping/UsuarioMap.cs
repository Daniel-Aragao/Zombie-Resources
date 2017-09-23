using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuarios");
            HasKey(u => u.Id);

            Property(u => u.Nome).IsRequired();
            Property(u => u.Login).IsRequired();
            Property(u => u.Senha).IsRequired();

        }
    }
}
