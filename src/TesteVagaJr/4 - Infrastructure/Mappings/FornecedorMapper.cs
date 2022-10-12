using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteVagaJr.Domain.Entities;

namespace TesteVagaJr.Infrastructure.Mappings;

public class FornecedorMapper : IEntityTypeConfiguration<Fornecedor>
{
    public void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("Fornecedores");

        builder.Property(x => x.DataHoraCadastro)
            .IsRequired();

        builder.Property(x => x.RG)
            .HasColumnType("VARCHAR(20)")
            .IsRequired(false);

        builder.HasOne(x => x.Empresa)
            .WithMany(x => x.Fornecedores)
            .HasForeignKey(x => x.EmpresaId);
    
    }
}