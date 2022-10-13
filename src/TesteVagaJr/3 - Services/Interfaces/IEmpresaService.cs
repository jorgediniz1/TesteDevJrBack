using TesteVagaJr.Domain.Entities;
using TesteVagaJr.Services.Dtos;

namespace TesteVagaJr.Services.Interfaces;

public interface IEmpresaService
{
    Task<FornecedorDto> AdicionarFornecedor(FornecedorDto fornecedorDto);
    Task<EmpresaDto>AdicionarEmpresa(EmpresaDto empresaDTO);
    Task RemoverEmpresa(Guid id);
    Task<EmpresaDto> PegarEmpresaAsync(Guid empresaId);
    Task<IEnumerable<EmpresaDto>> PegarTodasEmpresasAsync();
    Task<IEnumerable<FornecedorDto>> PegarTodosFornecedoresDeUmaEmpresa(Guid empresaId);
    Task<List<FornecedorDto>> FiltrarFornecedorPorNome(string nome);
    Task<List<FornecedorDto>> FiltrarFornecedorPorNumeroDocumento(string numeroDocumento);
    Task<List<FornecedorDto>> FiltrarFornecedorPorDataCadastro(string dataCadastro);



}