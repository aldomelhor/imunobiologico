using Microsoft.EntityFrameworkCore;
using Imunobiologico.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imunobiologico.EntityFramework.Data.Mapeamentos
{
    public class ImunobiologicoMap : IEntityTypeConfiguration<EntityFramework.Models.Imunobiologico>
    {

        public void Configure(EntityTypeBuilder<Imunobiologico.EntityFramework.Models.Imunobiologico> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Fabricante)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.AnoLote)
                .IsRequired();

            builder.ToTable("Imunobiologico");
        }
    }
}
