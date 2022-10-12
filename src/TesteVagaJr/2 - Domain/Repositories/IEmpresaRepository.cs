using TesteVagaJr.Core;
using TesteVagaJr.Domain.Entities;

namespace TesteVagaJr.Domain.Repositories;

public interface IEmpresaRepository
{
   
    void CadastrarEmpresa(Empresa empresa);

    Task<IEnumerable<Empresa>> GetAllEmpresasAsync();
    Task<Empresa> GetEmpresaAsync(Guid id);


    Task<Empresa> GetEmpresaByCnpj(string cnpj);


    void AdicionarFornecedor(Fornecedor fornecedor);
    void RemoverFornecedor(Guid id);
    Task<Fornecedor> GetFornecedorById(Guid id);
    Task<IEnumerable<Fornecedor>> GetAllFornecedoresDeUmaEmpresa(Guid empresaId);

    IUnitOfWork UnitOfWork { get; }
}