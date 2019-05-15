﻿// <auto-generated />
using System;
using EFcoreWithAspNetcore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFcoreWithAspNetcore.Domain.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFcoreWithAspNetcore.Domain.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("EFcoreWithAspNetcore.Domain.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<bool>("EhAtivo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("money");

                    b.Property<int>("QtdEmEstoque");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("EhAtivo");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("EFcoreWithAspNetcore.Domain.ProdutoPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Binario")
                        .IsRequired();

                    b.Property<bool>("EhPrincipal");

                    b.Property<string>("Extensao")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("NomeDoArquivo")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("ProdutoId");

                    b.Property<int>("Tamanho");

                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutosPhotos");
                });

            modelBuilder.Entity("EFcoreWithAspNetcore.Domain.Produto", b =>
                {
                    b.HasOne("EFcoreWithAspNetcore.Domain.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFcoreWithAspNetcore.Domain.ProdutoPhoto", b =>
                {
                    b.HasOne("EFcoreWithAspNetcore.Domain.Produto", "Produto")
                        .WithMany("Photos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
