using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFcoreWithAspNetcore.Domain.Mappings
{
    class ProdutoPhotoMap :IEntityTypeConfiguration<ProdutoPhoto>
    {
        public void Configure(EntityTypeBuilder<ProdutoPhoto> builder)
        {
            builder.ToTable("ProdutosPhotos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Extensao).HasColumnType("varchar(8)").IsRequired();
            builder.Property(p => p.NomeDoArquivo).HasColumnType("varchar(200)").IsRequired();
            builder.Property(p => p.Binario).IsRequired();
            builder.Property(p => p.Tipo).HasColumnType("varchar(40)");
        }
    }
}
