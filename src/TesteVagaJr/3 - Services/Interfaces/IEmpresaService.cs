using TesteVagaJr.Domain.Entities;
using TesteVagaJr.Services.Dtos;

namespace TesteVagaJr.Services.Interfaces;

public interface IEmpresaService
{
    Task<FornecedorDto> AdicionarFornecedor(FornecedorDto fornecedorDto);
    Task<EmpresaDto>AdicionarEmpresa(EmpresaDto empresaDTO);
    Task<EmpresaDto> PegarEmpresaAsync(Guid empresaId);
    Task<IEnumerable<EmpresaDto>> PegarTodasEmpresasAsync();
    Task<IEnumerable<FornecedorDto>> PegarFornecedoresAsync(Guid empresaId);
    Task<List<FornecedorDto>> FiltrarFornecedorPorNome(string nome);
    Task<List<FornecedorDto>> FiltrarFornecedorPorNumeroDocumento(string numeroDocumento);
    Task<List<FornecedorDto>> FiltrarFornecedorPorDataCadastro(string dataCadastro);



}