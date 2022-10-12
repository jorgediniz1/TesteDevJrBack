using AutoMapper;
using TesteVagaJr.Domain.Entities;
using TesteVagaJr.Services.Dtos;
using TesteVagaJr.ViewModels;

namespace TesteVagaJr.Services.Profiles;

public class EmpresaProfile : Profile
{
    public EmpresaProfile()
    {
        CreateMap<Empresa, EmpresaDto>().ReverseMap();
        CreateMap<EmpresaDto, CadastrarEmpresaViewModel>().ReverseMap();
        CreateMap<EmpresaDto, ResultViewModel>().ReverseMap();
        CreateMap<Fornecedor, FornecedorDto>().ReverseMap();
    }
}