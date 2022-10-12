using TesteVagaJr.Domain.Entities;

namespace TesteVagaJr.Services.Dtos;

public class FornecedorDto
{
    public Guid Id { get; set; }
    public string Nome { get; private set; }
    public string NumeroDocumento { get; private set; }
    public ETipoDocumento TipoDocumento { get; private set; }
    public ETipoFornecedor TipoFornecedor { get; private set; }
    public DateTime DataHoraCadastro { get; set; }
    public List<Telefone> Telefones { get; private set; }
    public DateTime? DataNascimento { get; private set; }
    public string RG { get; private set; }

    public Guid EmpresaId { get; private set; }
    public Empresa Empresa { get; set; }

    public FornecedorDto(Guid id, string nome, string numeroDocumento, ETipoDocumento tipoDocumento, ETipoFornecedor tipoFornecedor, DateTime dataHoraCadastro, List<Telefone> telefones, DateTime? dataNascimento, string rg, Guid empresaId, Empresa empresa)
    {   
        Id = id;
        Nome = nome;
        NumeroDocumento = numeroDocumento;
        TipoDocumento = tipoDocumento;
        TipoFornecedor = tipoFornecedor;
        DataHoraCadastro = dataHoraCadastro;
        Telefones = telefones;
        DataNascimento = dataNascimento;
        RG = rg;
        EmpresaId = empresaId;
        Empresa = empresa;
    }
}