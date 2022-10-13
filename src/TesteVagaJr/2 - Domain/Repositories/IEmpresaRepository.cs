using TesteVagaJr.Core;
using TesteVagaJr.Domain.Entities;

namespace TesteVagaJr.Domain.Repositories;

public interface IEmpresaRepository
{
   
    void CadastrarEmpresa(Empresa empresa);
    Task RemoverEmpresa(Guid id);

    Task<IEnumerable<Empresa>> PegarTodasEmpresas();
    Task<Empresa> GetEmpresaAsync(Guid id);
    Task<Empresa> GetEmpresaByCnpj(string cnpj);
    void AdicionarFornecedor(Fornecedor fornecedor);
    void RemoverFornecedor(Guid id);
    Task<Fornecedor> GetFornecedorById(Guid id);
    Task<IEnumerable<Fornecedor>> GetAllFornecedoresDeUmaEmpresa(Guid empresaId);
    Task<List<Fornecedor>> FiltrarFornecedorPorNumeroDocumento(string numeroDocumento);
    Task<List<Fornecedor>> FiltrarFornecedorPorNome(string nome);
    Task<List<Fornecedor>> FiltrarFornecedorPorDataCadastro(string dataCadastro);


    IUnitOfWork UnitOfWork { get; }
}