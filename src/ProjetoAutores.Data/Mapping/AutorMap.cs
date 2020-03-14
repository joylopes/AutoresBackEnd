using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAutores.Domain.Entities;

namespace ProjetoAutores.Data.Mapping
{
    public class AutorMap : IEntityTypeConfiguration<AutorEntity>
    {
        public void Configure(EntityTypeBuilder<AutorEntity> builder)
        {
            builder.ToTable("Autor");

            builder.HasKey(p => p.Id);
            builder.Property(a => a.Nome)
                   .IsRequired()
                   .HasMaxLength(60);
            builder.Property(a => a.DataDeCadastro);
        }
    }
}
