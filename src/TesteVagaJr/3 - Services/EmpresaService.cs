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

    public async Task<EmpresaDto> AddEmpresaAsync(EmpresaDto empresaDto)
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
    

    public Task<EmpresaDto> GetEmpresaAsync(Guid empresaId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<EmpresaDto>> GetAllEmpresasAsync()
    {
        var empresas = await _empresaRepository.GetAllEmpresasAsync();
       
        return _mapper.Map<IEnumerable<EmpresaDto>>(empresas);
    }

    public Task<IEnumerable<FornecedorDto>> GetFornecedorAsync(Guid empresaId)
    {
        throw new NotImplementedException();
    }

    
}