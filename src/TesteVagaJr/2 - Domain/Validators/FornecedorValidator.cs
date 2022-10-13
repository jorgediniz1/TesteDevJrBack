using FluentValidation;
using TesteVagaJr.Domain.Entities;

namespace TesteVagaJr.Domain.Validators;

public class FornecedorValidator : AbstractValidator<Fornecedor>
{

    public FornecedorValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("A entidade não pode ser vazia")

            .NotNull()
            .WithMessage("A entidade não pode ser nula");

        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O nome não pode ser vazio")

            .NotNull()
            .WithMessage("O nome não pode ser nulo");


        RuleFor(x => x.NumeroDocumento)
            .NotEmpty()
            .WithMessage("O documento não pode ser vazio")

            .NotNull()
            .WithMessage("O documento não pode ser nulo");

        RuleFor(x => x.DataHoraCadastro)
            .NotEmpty()
            .WithMessage("A data e hora do cadastro não podem ser vazias")

            .NotNull()
            .WithMessage("A data e hora de cadastro não podem ser nulas");

        //RuleFor(x => x.DataNascimento)
        //    .Must(FornecedorPfMaiorDeIdade)
        //    .WithMessage("O fornecedor pf deve ser maior de idade");


        RuleFor(x => x.TipoDocumento)
            .NotEmpty()
            .WithMessage("O tipo do documento não pode ser vazio")

            .NotNull()
            .WithMessage("O tipo do documento não pode ser nulo");

        RuleFor(x => x.TipoFornecedor)
            .NotEmpty()
            .WithMessage("O tipo de fornecedor não pode ser vazio")

            .NotNull()
            .WithMessage("O tipo do fornecedor não pode ser nulo");


        RuleFor(x => x.Telefones)
            .NotEmpty()
            .WithMessage("Os telefones não podem ser vazios")

            .NotNull()
            .WithMessage("Os telefones não podem ser nulos");
    }
    //private static bool FornecedorPfMaiorDeIdade(DateTime dataNascimento)
    //{
    //    return dataNascimento <= DateTime.Now.AddYears(-18); 
    //}
}