using ProjetoAutores.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAutores.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<AutorEntity> Autores { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
