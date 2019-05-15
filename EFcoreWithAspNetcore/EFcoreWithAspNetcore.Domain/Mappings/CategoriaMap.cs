using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFcoreWithAspNetcore.Domain.Mappings
{
    class CategoriaMap :IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Descricao).HasColumnType("varchar(200)").IsRequired();
        }
    }
}
