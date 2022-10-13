using Microsoft.EntityFrameworkCore;
using TesteVagaJr.Core;
using TesteVagaJr.Domain.Entities;
using TesteVagaJr.Domain.Repositories;

namespace TesteVagaJr.Infrastructure.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly ApplicationDbContext _context;
    public EmpresaRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public IUnitOfWork UnitOfWork => _context;

    public void AdicionarFornecedor(Fornecedor fornecedor)
    {
        _context.Fornecedores.Add(fornecedor);
    }

    public void RemoverFornecedor(Guid id)
    {
        throw new Exception();
    }

    public void CadastrarEmpresa(Empresa empresa)
    {
        _context.Empresas.Add(empresa);
    }

    public async Task RemoverEmpresa(Guid id)
    {
        var empresa = await PegarEmpresaByIdAsync(id);

        if (empresa != null)
        {
            _context.Empresas.Remove(empresa);
        }
    }

    public async Task<IEnumerable<Empresa>> PegarTodasEmpresas()
    {
        var empresas = await _context.Empresas.AsNoTracking().ToListAsync();

        return empresas;
    }

    public async Task<Empresa> PegarEmpresaByIdAsync(Guid id)
    {
        var empresa = await _context.Empresas.SingleOrDefaultAsync(x => x.Id == id);

        return empresa;
    }

    public async Task<Empresa> PegarEmpresaPorCnpj(string cnpj)
    {
        var empresa = await _context.Empresas
                                .Where(x => x.Cnpj == cnpj)
                                .AsNoTracking()
                                .ToListAsync();

        return empresa.FirstOrDefault();

    }

    public async Task<Fornecedor> PegarFornecedorPorId(Guid id)
    {
        var fornecedor = await _context.Fornecedores
            .Where(x => x.Id == id)
            .AsNoTracking()
            .ToListAsync();

        return fornecedor.FirstOrDefault();

    }

    public async Task<IEnumerable<Fornecedor>> PegarTodosFornecedoresDeUmaEmpresa(Guid empresaId)
    {
        var fornecedores = await _context.Fornecedores.Where(x => x.EmpresaId == empresaId).ToListAsync();

        return fornecedores;
    }

    public async Task<List<Fornecedor>> FiltrarFornecedorPorNome(string nome)
    {
        var fornecedores = await _context.Fornecedores.Where(x => x.Nome.ToLower().Contains(nome.ToLower()))
                                                                       .AsNoTracking()
                                                                       .ToListAsync();
        return fornecedores;

    }

    public async Task<List<Fornecedor>> FiltrarFornecedorPorNumeroDocumento(string numeroDocumento)
    {
        var fornecedor = await _context.Fornecedores.Where(x => x.NumeroDocumento.Contains(numeroDocumento))
                                                                       .AsNoTracking()
                                                                       .ToListAsync();
        return fornecedor;
    }

    public async Task<List<Fornecedor>> FiltrarFornecedorPorDataCadastro(string dataCadastro)
    {
        var fornecedores = await _context.Fornecedores.Where(x => x.DataHoraCadastro.ToString().Contains(dataCadastro))
                                                                        .AsNoTracking()
                                                                        .ToListAsync();
        return fornecedores;
    }

    public async void UpdateEmpresaAsync(Empresa empresa)
    {
        _context.Empresas.Update(empresa);
    }
}