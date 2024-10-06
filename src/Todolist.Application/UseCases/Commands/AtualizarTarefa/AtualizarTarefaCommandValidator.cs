using FluentValidation;
using Todolist.Application.UseCases.Commands.AtualizarTarefa;
using Todolist.Domain.Enum;

namespace Todolist.Application.UseCases.Commands.CriarProjeto
{
    public class AtualizarTarefaCommandValidator : AbstractValidator<AtualizarTarefaCommand>
    {
        public AtualizarTarefaCommandValidator()
        {
            RuleFor(c => c.TarefaId)
             .GreaterThan(0)
             .WithMessage("Campo {PropertyName} deve ser maior que zero. Valor atual: '{PropertyValue}'");
           
            RuleFor(c => c.PrioridadeId)
             .Must(BeAValidPriority)
             .WithMessage("Campo {PropertyName} deve ser uma prioridade válida. Valor atual: '{PropertyValue}'")
             .When(c => c.PrioridadeId.HasValue);

            RuleFor(c => c.Nome)
               .MaximumLength(280)
               .When(c => !string.IsNullOrWhiteSpace(c.Nome))
               .WithMessage("Campo {PropertyName} deve ter no máximo 280 caracteres. Valor atual: '{PropertyValue}'");

            RuleFor(c => c.Descricao)
             .MaximumLength(280)
             .When(c => !string.IsNullOrWhiteSpace(c.Descricao))
             .WithMessage("Campo {PropertyName} deve ter no máximo 1000 caracteres. Valor atual: '{PropertyValue}'");

            RuleFor(c => c.DataFinal)
               .GreaterThanOrEqualTo(DateTime.Now)
               .When(c => c.DataFinal.HasValue)
               .WithMessage("Campo {PropertyName}, se fornecido, deve ser maior ou igual à data atual. Valor atual: '{PropertyValue}'");

            RuleFor(c => c.ResponsavelId)
                .GreaterThan(0)
                 .When(c => c.ResponsavelId.HasValue)
                .WithMessage("Campo {PropertyName} deve ser maior que zero. Valor atual: '{PropertyValue}'");

        }

        private bool BeAValidPriority(int? prioridadeId)
        {
            return Enum.IsDefined(typeof(TipoPrioridadeEnum), prioridadeId!);
        }

    }
}
