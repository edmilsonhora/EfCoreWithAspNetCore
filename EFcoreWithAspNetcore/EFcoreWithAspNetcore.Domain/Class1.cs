using System;
using System.Collections.Generic;
using EFcoreWithAspNetcore.Domain.Mappings;
using Microsoft.EntityFrameworkCore;



namespace EFcoreWithAspNetcore.Domain
{
    public class MyContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=DbEfWithAspNet;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoPhotoMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ProdutoPhoto> ProdutoPhotos { get; set; }
    }

    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public bool EhAtivo { get; set; }
        public int QtdEmEstoque { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public List<ProdutoPhoto> Photos { get; set; }

        public Produto()
        {
            Photos = new List<ProdutoPhoto>();
        }
    }

    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }

    public class ProdutoPhoto
    {
        public int Id { get; set; }
        public string NomeDoArquivo { get; set; }
        public string Extensao { get; set; }
        public byte[] Binario { get; set; }
        public string Tipo { get; set; }
        public int Tamanho { get; set; }
        public bool EhPrincipal { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }


}
