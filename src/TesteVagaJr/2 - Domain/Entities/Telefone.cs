using TesteVagaJr.Core.Exceptions;
using TesteVagaJr.Domain.Validators;

namespace TesteVagaJr.Domain.Entities;

public class Telefone : Entity
{
    public string DDD { get; private set; }
    public string Numero { get; private set; }


    public override string ToString() => $"({DDD}) {Numero}";

    public Telefone(string DDD, string numero)
    {
        this.DDD = DDD;
        this.Numero = numero;

        _errors = new List<string>();
        Validate();
    }



    public override bool Validate()
    {
        var validator = new TelefoneValidator();
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