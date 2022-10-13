using AutoMapper;
using TesteVagaJr.Core.Exceptions;
using TesteVagaJr.Domain.Entities;
using TesteVagaJr.Domain.Repositories;
using TesteVagaJr.Services.Dtos;
using TesteVagaJr.Services.Interfaces;

namespace TesteVagaJr.Services;

public class EmpresaService : IEmpresaService
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IMapper _mapper;
    public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper)
    {
        _empresaRepository = empresaRepository;
        _mapper = mapper;
    }

    public async Task<EmpresaDto> AdicionarEmpresa(EmpresaDto empresaDto)
    {
        var empresaExists = await _empresaRepository.GetEmpresaByCnpj(empresaDto.Cnpj);

        if(empresaExists != null)
        {
            throw new DomainException("Já existe empresa cadastrada com o cnpj informado");
        }

        var empresa = _mapper.Map<Empresa>(empresaDto);
        empresa.Validate();

         _empresaRepository.CadastrarEmpresa(empresa);
         
         var success = await _empresaRepository.UnitOfWork.Commit();

         if(success)
         {
            return empresaDto;
         }

         return default;    

    }

    public async Task<FornecedorDto> AdicionarFornecedor(FornecedorDto fornecedorDto)
    {
        var fornecedorExists = await _empresaRepository.GetFornecedorById(fornecedorDto.Id);

        if (fornecedorExists != null)
        {
            throw new DomainException("O fornecedor informado já existe nesta empresa.");
        }

        var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);
        fornecedor.Validate();

        _empresaRepository.AdicionarFornecedor(fornecedor);

        var success = await _empresaRepository.UnitOfWork.Commit();

        if (success)
        {
            return fornecedorDto;
        }

        return default;
    }
    

    public Task<EmpresaDto> PegarEmpresaAsync(Guid empresaId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<EmpresaDto>> PegarTodasEmpresasAsync()
    {
        var empresas = await _empresaRepository.PegarTodasEmpresas();
       
        return _mapper.Map<IEnumerable<EmpresaDto>>(empresas);
    }

    public Task<IEnumerable<FornecedorDto>> PegarFornecedoresAsync(Guid empresaId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<FornecedorDto>> FiltrarFornecedorPorNome(string nome)
    {
        var fornecedores = await _empresaRepository.FiltrarFornecedorPorNome(nome);
        return _mapper.Map<List<FornecedorDto>>(fornecedores);
    }

    public async Task<List<FornecedorDto>> FiltrarFornecedorPorNumeroDocumento(string numeroDocumento)
    {
        var fornecedor = await _empresaRepository.FiltrarFornecedorPorNumeroDocumento(numeroDocumento);
        return _mapper.Map<List<FornecedorDto>>(fornecedor);
    }

    public async Task<List<FornecedorDto>> FiltrarFornecedorPorDataCadastro(string dataCadastro)
    {
        var fornecedores = await _empresaRepository.FiltrarFornecedorPorDataCadastro(dataCadastro);
        return _mapper.Map<List<FornecedorDto>>(fornecedores);
    }
}