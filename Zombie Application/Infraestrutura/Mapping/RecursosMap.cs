using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Mapping
{
    public class RecursosMap : EntityTypeConfiguration<Recurso>
    {
        public RecursosMap()
        {
            ToTable("Recursos");
            HasKey(r => r.Id);

            Property(r => r.Descricao).IsRequired();
            Property(r => r.Quantidade).IsRequired();
            Property(r => r.isActive).IsRequired();
            Property(r => r.Observacao).IsOptional();

            Ignore(r => r.IsDisponivel);
        }
    }
}
