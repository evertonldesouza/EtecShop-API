using EtecShopAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtecShopAPI.Data
{
    public class Contexto : DbContext
    {
        public Contexto (DbContextOptions<Contexto>options): base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }
        public DbSet<ProdutoComentario> ProdutoComentarios { get; set; }
        public DbSet<ProdutoFoto> ProdutoFotos { get; set; }
        public DbSet<ProdutoRelacionado> ProdutoRelacionados { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Configuração dos Comentarios em Produtos
            //Relacionamento e Chave Estrangeira com Cliente
            builder.Entity<ProdutoComentario>()
                .HasOne(pc => pc.Cliente)
                .WithMany(c => c.Comentarios)
                .HasForeignKey(pc => pc.ClienteId);
            //Relacionamento e Chave Estrangeira com Produto
            builder.Entity<ProdutoComentario>()
                .HasOne(pc => pc.Produto)
                .WithMany(c => c.Comentarios)
                .HasForeignKey(pc => pc.ProdutoId);
            #endregion

            #region Configuração dos Produto Categoria
            //ChavePrimaria composta
            builder.Entity<ProdutoCategoria>().HasKey(pc => new { pc.ProdutoId, pc.CategoriaId });
            //Relacionamento e Chave Estrangeira com Produto
            builder.Entity<ProdutoCategoria>()
                .HasOne(pc => pc.Produto)
                .WithMany(p => p.Categorias)
                .HasForeignKey(pc => pc.ProdutoId);
            //Relacionamento e Chave Estrangeira com categoria
            builder.Entity<ProdutoCategoria>()
                .HasOne(pc => pc.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(pc => pc.CategoriaId);
            #endregion

            #region Configuração dos Produto Relacionado
            //ChavePrimaria composta
            builder.Entity<ProdutoRelacionado>().HasKey(pr => new {pr.ProdutoId, pr.ProdutoSimilarId });
            //relacionamento e chave estrangeira com produto
            builder.Entity<ProdutoRelacionado>()
                .HasOne(pr => pr.Produto)
                .WithMany(p => p.Similares)
                .HasForeignKey(pr => pr.ProdutoId);
            //Relacionamento e Chave Estrangeira com categoria
            builder.Entity<ProdutoRelacionado>()
                .HasOne(pr => pr.Similar)
                .WithMany(p => p.Relacionados)
                .HasForeignKey(pr => pr.ProdutoSimilarId);
            #endregion

            #region Configuração da lista de desejo
            //ChavePrimaria composta
            builder.Entity<ListaDesejo>().HasKey(ld => new { ld.ClienteId, ld.ProdutoId });
            //relacionamento e chave estrangeira com cliente
            builder.Entity<ListaDesejo>()
                .HasOne(ld => ld.Cliente)
                .WithMany(c => c.ListaInteresse)
                .HasForeignKey(ld => ld.ProdutoId);
            //Relacionamento e Chave Estrangeira com produto
            builder.Entity<ListaDesejo>()
                .HasOne(ld => ld.Produto)
                .WithMany(p => p.ClientesInteressados)
                .HasForeignKey(ld => ld.ProdutoId);
            #endregion

            #region Popular Categoria
            builder.Entity<Categoria>().HasData(
                new Categoria()
                {
                    Id=1,
                    Nome="Notebooks"
                },
                new Categoria()
                {
                    Id = 2,
                    Nome = "smartphones"
                },
                new Categoria()
                {
                    Id = 3,
                    Nome = "Cameras"
                },
                new Categoria()
                {
                    Id = 4,
                    Nome = "Acessórios"
                },
                new Categoria()
                {
                    Id = 5,
                    Nome = "Gamer"
                }
                );
            #endregion

            #region Popular Marca
            builder.Entity<Marca>().HasData(
                new Marca()
                {
                    Id = 1,
                    Nome = "Samsung"
                },
                new Marca()
                {
                    Id = 2,
                    Nome = "LG"
                },
                new Marca()
                {
                    Id = 3,
                    Nome = "Sony"
                },
                new Marca()
                {
                    Id = 4,
                    Nome = "Dell"
                },
                new Marca()
                {
                    Id = 5,
                    Nome = "Motorola"
                }
                );
            #endregion

            #region Popular Cliente
            builder.Entity<Cliente>().HasData(
                new Cliente()
                {
                    Id = 1,
                    Nome = "JoãoAugusto Fulano",
                    Email= "joaoaugustofulano@gmail.com",
                    Telefone="14999998888"
                },
                 new Cliente()
                 {
                     Id = 2,
                     Nome = "João Augusto Fulano",
                     Email = "joaoaugustofulano@gmail.com",
                     Telefone = "14999997777"
                 },
                 new Cliente()
                 {
                     Id = 3,
                     Nome = "José Roberto Ciclano",
                     Email = "joserobertociclano@gmail.com",
                     Telefone = "14999996666"
                 },
                 new Cliente()
                 {
                     Id = 4,
                     Nome = "Joaquim Beltrano",
                     Email = "joaquimbeltrano@gmail.com",
                     Telefone = "14999995555"
                 },
                 new Cliente()
                 {
                     Id = 5,
                     Nome = "Felizberto da Silva",
                     Email = "felizbertodasilva@gmail.com",
                     Telefone = "14999994444"
                 }
                );
            #endregion

            #region Popular Produto
            builder.Entity<Produto>().HasData(
                new Produto()
                {
                    Id = 1,
                    Nome = "Notebook samsung Windows 10",
                    Descricao = "Notebook samsung Windows 10,i5,16gb",
                    Detalhes = "Notebook samsung Windows 10,i5,16gb - É tão bom",
                    Preco = 4000,
                    Estoque= 10,
                    CategoriaId=1,
                    MarcaId=1
                },
                 new Produto()
                 {
                     Id = 2,
                     Nome = "Fone de Ouvido Sony XPTO",
                     Descricao = "Fone de Ouvido Sony XPTO",
                     Detalhes = "Fone de Ouvido Sony XPTO - É tão bom",
                     Preco = 300,
                     Estoque = 4,
                     CategoriaId = 5,
                     MarcaId = 3
                 },
                 new Produto()
                 {
                     Id = 3,
                     Nome = "Smartphone Motorola G20",
                     Descricao = "Smartphone Motorola G20",
                     Detalhes = "Smartphone Motorola G20",
                     Preco = 1000,
                     Estoque = 20,
                     CategoriaId = 2,
                     MarcaId = 5
                 },
                 new Produto()
                 {
                     Id = 4,
                     Nome = "Smartphone Motorola G20",
                     Descricao = "Smartphone Motorola G20",
                     Detalhes = "Smartphone Motorola G20",
                     Preco = 4000,
                     Estoque = 13,
                     CategoriaId = 2,
                     MarcaId = 1
                 },
                 new Produto()
                 {
                     Id = 5,
                     Nome = "Notebook Dell G3",
                     Descricao = "Notebook Dell G3,i5,16gb",
                     Detalhes = "Notebook Dell G3,i5,16gb - É tão bom",
                     Preco = 6000,
                     Estoque = 10,
                     CategoriaId = 1,
                     MarcaId = 4
                 }
                );
            #endregion
        }


    }
}
