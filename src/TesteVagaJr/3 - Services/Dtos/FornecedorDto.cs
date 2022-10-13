using System.Globalization;
using System.Text.Json.Serialization;
using TesteVagaJr.Domain.Entities;

namespace TesteVagaJr.Services.Dtos;

public class FornecedorDto
{
    public Guid Id { get; set; }
    public string Nome { get;  set; }
    public string NumeroDocumento { get;  set; }
    public ETipoDocumento TipoDocumento { get;  set; }
    public ETipoFornecedor TipoFornecedor { get;  set; }
    public List<Telefone> Telefones { get;  set; }
    public DateTime? DataNascimento { get;  set; }
    public DateTime DataHoraCadastro { get; set; }
    public string RG { get;  set; }
    public Guid EmpresaId { get;  set; }

    public FornecedorDto()
    {
    }

}