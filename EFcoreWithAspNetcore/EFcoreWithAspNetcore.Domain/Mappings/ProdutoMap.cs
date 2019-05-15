using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFcoreWithAspNetcore.Domain.Mappings
{
    class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasIndex(p => p.EhAtivo);
            builder.Property(p => p.Nome).HasColumnType("varchar(200)").IsRequired();
            builder.Property(p => p.Preco).HasColumnType("money").IsRequired();
            builder.HasQueryFilter(p => p.EhAtivo == true);
        }
    }
}
