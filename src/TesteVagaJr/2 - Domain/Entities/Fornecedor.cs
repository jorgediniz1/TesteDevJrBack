using TesteVagaJr.Core.Exceptions;
using TesteVagaJr.Domain.Validators;

namespace TesteVagaJr.Domain.Entities;

public class Fornecedor : Entity
{
    public string Nome { get; private set; }
    public string NumeroDocumento { get; private set; }
    public ETipoDocumento TipoDocumento { get; private set; }
    public ETipoFornecedor TipoFornecedor { get; private set; }
    public DateTime DataHoraCadastro { get; set; }
    public List<Telefone> Telefones { get; private set; }
    public DateTime? DataNascimento { get; private set; }
    public string? RG { get; private set; }
    public Guid EmpresaId { get; private set; }
    public Empresa Empresa { get; set; }

    protected Fornecedor() { }

    public Fornecedor(string nome, string numeroDocumento, ETipoDocumento tipoDocumento, ETipoFornecedor tipoFornecedor, DateTime dataHoraCadastro, DateTime? dataNascimento, string? rg, Guid empresaId)
    {
        Nome = nome;
        NumeroDocumento = numeroDocumento;
        TipoDocumento = tipoDocumento;
        TipoFornecedor = tipoFornecedor;
        DataHoraCadastro = DateTime.UtcNow;
        DataNascimento = dataNascimento;
        RG = rg;
        EmpresaId = empresaId;
        _errors = new List<string>();
        Validate();
    }

    public void AdicionarTelefone(string DDD, string numero)
    {
        var telefone = new Telefone(DDD, numero);
        Telefones.Add(telefone);
    }

    public void RemoverTelefone(string numero)
    {
        var telefone = Telefones.FirstOrDefault(x => x.Numero == numero);
        Telefones.Remove(telefone);
    }

    public void ChangeNome(string nome)
    {
        Nome = nome;
        Validate();
    }

    public void ChangeNumeroDocumento(string numeroDocumento)
    {
        NumeroDocumento = numeroDocumento;
        Validate();
    }

    public void ChangeTipoDocumento(ETipoDocumento tipoDocumento)
    {
        TipoDocumento = tipoDocumento;
        Validate();
    }

    public void ChangeTipoFornecedor(ETipoFornecedor tipoFornecedor)
    {
        TipoFornecedor = tipoFornecedor;
        Validate();
    }

    public override bool Validate()
    {
        var validator = new FornecedorValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
            
                _errors.Add(error.ErrorMessage);

            throw new DomainException("Alguns campos estão inválidos", _errors);

        }

        return true;
    }
}
