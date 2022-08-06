using Microsoft.EntityFrameworkCore;
using ProvaSuficienciaWebII.Data.Mappings;
using ProvaSuficienciaWebII.Entities;

namespace ProvaSuficienciaWebII.Data.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        {

        }

        // tabelas
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Produto>(new ProdutoMapping());
            modelBuilder.ApplyConfiguration<Comanda>(new ComandaMapping());
            
        }
    }
}
