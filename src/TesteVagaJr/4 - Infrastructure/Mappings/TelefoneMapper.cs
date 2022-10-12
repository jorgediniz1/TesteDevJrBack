using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteVagaJr.Domain.Entities;

namespace TesteVagaJr.Infrastructure.Mappings
{
    public class TelefoneMapper : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Telefone");

            builder.Property(x => x.DDD)
            .HasColumnType("VARCHAR(2)")
            .IsRequired();

            builder.Property(x => x.Numero)
            .HasColumnType("VARCHAR(9)")
            .IsRequired();
        }
    }
}