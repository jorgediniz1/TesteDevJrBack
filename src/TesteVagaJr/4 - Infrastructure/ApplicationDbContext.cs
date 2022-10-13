using Microsoft.EntityFrameworkCore;
using TesteVagaJr.Core;
using TesteVagaJr.Domain.Entities;

namespace TesteVagaJr.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Telefone> Telefones { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public async Task<bool> Commit() => await base.SaveChangesAsync() > 0;

}