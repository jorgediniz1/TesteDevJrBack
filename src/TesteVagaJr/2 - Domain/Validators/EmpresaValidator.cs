using FluentValidation;
using TesteVagaJr.Domain.Entities;

namespace TesteVagaJr.Domain.Validators;

public class EmpresaValidator: AbstractValidator<Empresa>
{
    public EmpresaValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("A entidade não pode ser vazia")

            .NotNull()
            .WithMessage("A entidade não pode ser nula");
        
        RuleFor(x => x.Uf)
            .NotEmpty()
            .WithMessage("A uf não pode ser vazia")

            .NotNull()
            .WithMessage("A uf não pode ser nula");

        RuleFor(x => x.NomeFantasia)
            .NotEmpty()
            .WithMessage("O nome fantasia não pode ser vazio")

            .NotNull()
            .WithMessage("O nome fantasia não pode ser nulo");

        RuleFor(x => x.Cnpj)
            .NotEmpty()
            .WithMessage("O cnpj não pode ser vazio")

            .NotNull()
            .WithMessage("O cnpj não pode ser nulo");


    }
}