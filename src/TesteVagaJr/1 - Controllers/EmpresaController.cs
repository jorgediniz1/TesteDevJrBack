using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteVagaJr.Core.Exceptions;
using TesteVagaJr.Services.Dtos;
using TesteVagaJr.Services.Interfaces;
using TesteVagaJr.Utilities;
using TesteVagaJr.ViewModels;

namespace TesteVagaJr.Controllers;

public class EmpresaController : MainController
{
    private readonly IEmpresaService _empresaService;
    private readonly IMapper _mapper; 

    public EmpresaController(IEmpresaService empresaService, IMapper mapper)
    {
        _empresaService = empresaService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("/api/v1/empresas/adicionar")]
    public async Task<IActionResult> AdicionarEmpresa([FromBody] CadastrarEmpresaViewModel empresaViewModel)
    {
        try
        {
            var empresaDto = _mapper.Map<EmpresaDto>(empresaViewModel);

            var empresaAdicionar = await _empresaService.AdicionarEmpresa(empresaDto);

            return Ok(new ResultViewModel
            {
                Message = "Empresa criada com sucesso!",
                Success = true,
                Data = empresaAdicionar
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
    [HttpPost]
    [Route("/api/v1/empresas/adicionar-fornecedor")]

    public async Task<IActionResult> AdicionarFornecedor([FromBody] CadastrarFornecedorViewModel fornecedorViewModel)
    {
        try
        {
            var fornecedorDto = _mapper.Map<FornecedorDto>(fornecedorViewModel);

            var fornecedorAdicionar = await _empresaService.AdicionarFornecedor(fornecedorDto);

            return Ok(new ResultViewModel
            {
                Message = "Fornecedor adicionado com sucesso!",
                Success = true,
                Data = fornecedorAdicionar
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    [HttpGet]
    [Route("/api/v1/empresas/pegar-todas")]
    public async Task<IActionResult> PegarTodasEmpresas()
    {
        var empresas = await _empresaService.PegarTodasEmpresasAsync();
        try
        {
            return Ok(new ResultViewModel()
            {
                Message = "Empresas encontradas com sucesso!",
                Success = true,
                Data = empresas
            });
        }
        
        catch (DomainException ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    [HttpGet]
    [Route("/api/v1/users/filtrar-fornecedor-por-nome")]
    public async Task<IActionResult> FiltrarFornecedorPorNome([FromQuery] string nome)
    {
        try
        {
            var fornecedores = await _empresaService.FiltrarFornecedorPorNome(nome);

            if (fornecedores.Count == 0)
                return Ok(new ResultViewModel
                {
                    Message = "Nenhum Fornecedor foi encontrado com o nome informado.",
                    Success = true,
                    Data = null
                });

            return Ok(new ResultViewModel
            {
                Message = "Fornecedor encontrado com sucesso!",
                Success = true,
                Data = fornecedores
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    [HttpGet]
    [Route("/api/v1/users/filtrar-fornecedor-por-numero-documento")]
    public async Task<IActionResult> FiltrarFornecedorPorNumeroDocumento([FromQuery] string numeroDocumento)
    {
        try
        {
            var fornecedor = await _empresaService.FiltrarFornecedorPorNumeroDocumento(numeroDocumento);

            if (fornecedor.Count == 0)
                return Ok(new ResultViewModel
                {
                    Message = "Nenhum Fornecedor foi encontrado com o número de documento informado.",
                    Success = true,
                    Data = null
                });

            return Ok(new ResultViewModel
            {
                Message = "Fornecedor encontrado com sucesso!",
                Success = true,
                Data = fornecedor
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    [HttpGet]
    [Route("/api/v1/users/filtrar-fornecedor-por-data-cadastro")]
    public async Task<IActionResult> FiltrarFornecedorPorDataCadastro([FromQuery] string dataCadastro)
    {
        try
        {
            var fornecedores = await _empresaService.FiltrarFornecedorPorDataCadastro(dataCadastro);

            if (fornecedores.Count == 0)
                return Ok(new ResultViewModel
                {
                    Message = "Nenhum fornecedor foi encontrado com a data de criação informada.",
                    Success = true,
                    Data = null
                });

            return Ok(new ResultViewModel
            {
                Message = "Fornecedor encontrado com sucesso!",
                Success = true,
                Data = fornecedores
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }



    
}