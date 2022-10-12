using FluentValidation;
using TesteVagaJr.Domain.Entities;

namespace TesteVagaJr.Domain.Validators
{
    public class TelefoneValidator : AbstractValidator<Telefone>
    {
        public TelefoneValidator()
        {
            RuleFor(x => x.DDD)
            .NotEmpty()
            .WithMessage("O DDD não pode ser vazio")

            .NotNull()
            .WithMessage("O DDD não pode ser nulo");

            RuleFor(x => x.Numero)
            .NotEmpty()
            .WithMessage("O número não pode ser vazio")

            .NotNull()
            .WithMessage("O número não pode ser nulo");
            
        }
    }
}