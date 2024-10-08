using FluentValidation;

namespace Todolist.Application.UseCases.Commands.DeletarTarefa
{
    public class DeletarTarefaCommandValidator : AbstractValidator<DeletarTarefaCommand>
    {
        public DeletarTarefaCommandValidator()
        {
            RuleFor(c => c.TarefaId)
           .GreaterThan(0)
            .WithMessage("Campo {PropertyName} deve ser maior que 0. Valor atual: '{PropertyValue}'.");
        }

    }
}
