using ProjetoAutores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ProjetoAutores.Data.Mapping;

namespace ProjetoAutores.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<AutorEntity> Autores { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AutorEntity>(new AutorMap().Configure);
        }
    }
}
