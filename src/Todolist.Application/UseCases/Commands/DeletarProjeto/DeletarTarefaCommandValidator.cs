using FluentValidation;

namespace Todolist.Application.UseCases.Commands.DeletarProjeto
{
    public class DeletarProjetoCommandValidator : AbstractValidator<DeletarProjetoCommand>
    {
        public DeletarProjetoCommandValidator()
        {
            RuleFor(c => c.ProjetoId)
             .NotNull()
             .WithMessage("Campo {PropertyName} não pode ser nulo")
           .GreaterThan(0)
            .WithMessage("Campo {PropertyName} deve ser maior que 0. Valor atual: '{PropertyValue}'.");
        }

    }
}
