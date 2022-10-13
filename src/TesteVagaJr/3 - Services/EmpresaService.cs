using AutoMapper;
using FluentValidation.Validators;
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
        var empresaExists = await _empresaRepository.PegarEmpresaPorCnpj(empresaDto.Cnpj);

        if (empresaExists != null)
        {
            throw new DomainException("Já existe empresa cadastrada com o cnpj informado");
        }

        var empresa = _mapper.Map<Empresa>(empresaDto);
        empresa.Validate();

        _empresaRepository.CadastrarEmpresa(empresa);

        var success = await _empresaRepository.UnitOfWork.Commit();

        if (success)
        {
            return empresaDto;
        }

        return default;

    }

    public async Task<FornecedorDto> AdicionarFornecedor(FornecedorDto fornecedorDto)
    {
        fornecedorDto.DataHoraCadastro = DateTime.Now;
        var fornecedorExists = await _empresaRepository.PegarFornecedorPorId(fornecedorDto.Id);
        var empresa = await _empresaRepository.PegarEmpresaByIdAsync(fornecedorDto.EmpresaId);

        if (empresa == null)
        {
            throw new DomainException("A empresa que você tentou cadastrar o fornecedor não existe!");
        }

        if (fornecedorExists != null)
        {
            throw new DomainException("O fornecedor informado já existe nesta empresa.");
        }

        if (fornecedorDto.TipoFornecedor == ETipoFornecedor.Pf && fornecedorDto.RG != null && fornecedorDto.DataNascimento != null)
        {
            var birthdate = fornecedorDto.DataNascimento.Value.Year;
            var today = fornecedorDto.DataHoraCadastro.Year;
            var idade = today - birthdate;

            if (idade < 18) throw new DomainException("O fornecedor pessoa fisica não pode ser menor de idade");
        }else if(fornecedorDto.RG == null)
        {
          
        }else if(fornecedorDto.DataNascimento == null)
        {
            
        }

        if(fornecedorDto.TipoFornecedor == ETipoFornecedor.Pj)
        {
            fornecedorDto.RG = null;
            fornecedorDto.DataNascimento = null;
        }

        var fornecedor = new Fornecedor(fornecedorDto.Nome, fornecedorDto.NumeroDocumento, fornecedorDto.TipoDocumento,
        fornecedorDto.TipoFornecedor, fornecedorDto.DataHoraCadastro, fornecedorDto.DataNascimento, fornecedorDto.RG, fornecedorDto.EmpresaId);

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

    public async Task<IEnumerable<FornecedorDto>> PegarTodosFornecedoresDeUmaEmpresa(Guid empresaId)
    {
        var fornecedores = await _empresaRepository.PegarTodosFornecedoresDeUmaEmpresa(empresaId);

        return _mapper.Map<IEnumerable<FornecedorDto>>(fornecedores);
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

    public async Task RemoverEmpresa(Guid id)
    {
        await _empresaRepository.RemoverEmpresa(id);

        await _empresaRepository.UnitOfWork.Commit();
    }
}