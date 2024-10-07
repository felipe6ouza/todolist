using FluentValidation;

namespace Todolist.Application.UseCases.Commands.CriarProjeto
{
    public class CriarProjetoCommandValidator : AbstractValidator<CriarProjetoCommand>
    {
        public CriarProjetoCommandValidator()
        {
            RuleFor(command => command.AutorId)
            .GreaterThan(0)
         .WithMessage("Campo {PropertyName} deve ser maior que 0. Valor atual: '{PropertyValue}'.");

            RuleFor(command => command.Nome)
                .NotEmpty()
                .WithMessage("Campo {PropertyName} não pode estar vazio. Valor atual: '{PropertyValue}'.")
                .MaximumLength(150)
                .WithMessage("Campo {PropertyName} deve ter no máximo 150 caracteres. Valor atual: '{PropertyValue}'.");

            RuleFor(command => command.Favorito)
                .Must(x => x == true || x == false)
                .WithMessage("Campo {PropertyName} deve ser verdadeiro ou falso. Valor atual: '{PropertyValue}'.");
        }
    }
}
