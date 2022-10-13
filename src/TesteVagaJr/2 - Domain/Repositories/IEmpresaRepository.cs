using TesteVagaJr.Core;
using TesteVagaJr.Domain.Entities;

namespace TesteVagaJr.Domain.Repositories;

public interface IEmpresaRepository
{
   
    void CadastrarEmpresa(Empresa empresa);
    Task RemoverEmpresa(Guid id);

    Task<IEnumerable<Empresa>> PegarTodasEmpresas();
    Task<Empresa> PegarEmpresaByIdAsync(Guid id);
    Task<Empresa> PegarEmpresaPorCnpj(string cnpj);
    void UpdateEmpresaAsync(Empresa empresa);
    void AdicionarFornecedor(Fornecedor fornecedor);
    void RemoverFornecedor(Guid id);
    Task<Fornecedor> PegarFornecedorPorId(Guid id);
    Task<IEnumerable<Fornecedor>> PegarTodosFornecedoresDeUmaEmpresa(Guid empresaId);
    Task<List<Fornecedor>> FiltrarFornecedorPorNumeroDocumento(string numeroDocumento);
    Task<List<Fornecedor>> FiltrarFornecedorPorNome(string nome);
    Task<List<Fornecedor>> FiltrarFornecedorPorDataCadastro(string dataCadastro);


    IUnitOfWork UnitOfWork { get; }
}