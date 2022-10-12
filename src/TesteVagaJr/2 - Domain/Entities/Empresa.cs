using TesteVagaJr.Core.Exceptions;
using TesteVagaJr.Domain.Validators;

namespace TesteVagaJr.Domain.Entities;

public class Empresa : Entity
{
    public string Uf { get; private set; }
    public string NomeFantasia { get; private set; }
    public string Cnpj { get; private set; }

    //EF relation
    public List<Fornecedor> Fornecedores { get; set; }

    protected Empresa() {}

    public Empresa(string uf, string nomeFantasia, string cnpj)
    {
        Uf = uf;
        NomeFantasia = nomeFantasia;
        Cnpj = cnpj;
        _errors = new List<string>();
        Validate();
    }

    public void ChangeUf(string uf)
    {
        Uf = uf;
        Validate();
    }
    public void ChangeNomeFantasia(string nomeFantasia)
    {
        NomeFantasia = nomeFantasia;
        Validate();
    }

    public void ChangeCnpj(string cnpj)
    {
        Cnpj = cnpj;
        Validate();
    }

    public override bool Validate()
    {
        var validator = new EmpresaValidator();
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