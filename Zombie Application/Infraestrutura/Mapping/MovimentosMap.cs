using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Mapping
{
    public class MovimentosMap : EntityTypeConfiguration<Movimento>
    {
        public MovimentosMap()
        {
            ToTable("Movimentos");
            HasKey(m => m.Id);

            Property(m => m.Antes).IsRequired();
            Property(m => m.Depois).IsRequired();
            Property(m => m.Descricao).IsRequired();
            Property(m => m.Data).IsRequired();
            Property(m => m.TipoMovimento).IsRequired();

            HasRequired(m => m.Responsavel)
                .WithMany()
                .HasForeignKey(m => m.ResponsavelId);

            HasRequired(m => m.Recurso)
                .WithMany()
                .HasForeignKey(m => m.RecursoId);
        }
    }
}
