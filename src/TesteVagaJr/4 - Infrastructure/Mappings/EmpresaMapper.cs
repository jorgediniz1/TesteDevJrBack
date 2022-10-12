using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteVagaJr.Domain.Entities;

namespace TesteVagaJr.Infrastructure.Mappings;

public class EmpresaMapper : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("Empresas");

        builder.Property(x => x.Cnpj)
            .HasColumnType("VARCHAR(15)")
            .IsRequired();

        builder.Property(x => x.NomeFantasia)
            .HasColumnType("VARCHAR(100)")
            .IsRequired();

        builder.Property(x => x.Uf)
            .HasColumnType("VARCHAR(2)")
            .IsRequired();
    }
}