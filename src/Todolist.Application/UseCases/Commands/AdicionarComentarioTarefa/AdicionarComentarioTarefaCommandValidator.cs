using FluentValidation;

namespace Todolist.Application.UseCases.Commands.AdicionarComentarioTarefa
{
    public class AdicionarComentarioTarefaCommandValidator : AbstractValidator<AdicionarComentarioTarefaCommand>
    {
        public AdicionarComentarioTarefaCommandValidator()
        {
            RuleFor(command => command.AutorId)
                .GreaterThan(0)
                .WithMessage("Campo {PropertyName} deve ser maior que 0. Valor atual: '{PropertyValue}'.");

            RuleFor(command => command.TarefaId)
              .GreaterThan(0)
              .WithMessage("Campo {PropertyName} deve ser maior que 0. Valor atual: '{PropertyValue}'.");

            RuleFor(command => command.Descricao)
                .NotEmpty()
                .WithMessage("Campo {PropertyName} não pode estar vazio. Valor atual: '{PropertyValue}'.")
                .MaximumLength(1000)
                .WithMessage("Campo {PropertyName} deve ter no máximo 1000 caracteres. Valor atual: '{PropertyValue}'.");
        }
    }
}
