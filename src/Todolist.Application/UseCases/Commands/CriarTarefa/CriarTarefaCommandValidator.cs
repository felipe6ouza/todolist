using FluentValidation;
using Todolist.Domain.Enum;

namespace Todolist.Application.UseCases.Commands.CriarTarefa
{
    public class CriarTarefaCommandValidator : AbstractValidator<CriarTarefaCommand>
    {
        public CriarTarefaCommandValidator()
        {
            RuleFor(c => c.ProjetoId)
                .GreaterThan(0)
                .WithMessage("Campo {PropertyName} deve ser maior que zero. Valor atual: '{PropertyValue}'");

            RuleFor(c => c.PrioridadeId)
              .NotNull()
              .WithMessage("A prioridade é obrigatória.")
              .GreaterThan(0)
              .WithMessage("Campo {PropertyName} deve ser maior que zero. Valor atual: '{PropertyValue}'")
              .Must(BeAValidPriority)
              .WithMessage("Campo {PropertyName} deve ser uma prioridade válida. Valor atual: '{PropertyValue}'");

            RuleFor(c => c.AutorId)
                .GreaterThan(0)
                .WithMessage("Campo {PropertyName} deve ser maior que zero. Valor atual: '{PropertyValue}'");

            RuleFor(c => c.ResponsavelId)
                .GreaterThan(0)
                 .When(c => c.ResponsavelId.HasValue)
                .WithMessage("Campo {PropertyName} deve ser maior que zero. Valor atual: '{PropertyValue}'");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Campo {PropertyName} é obrigatório.")
                .MaximumLength(280)
                .WithMessage("Campo {PropertyName} deve ter no máximo 280 caracteres. Valor atual: '{PropertyValue}'");

            RuleFor(c => c.Descricao)
                .NotEmpty()
                .WithMessage("Campo {PropertyName} é obrigatório.")
                .MaximumLength(1000)
                .WithMessage("Campo {PropertyName} deve ter no máximo 1000 caracteres. Valor atual: '{PropertyValue}'");

            RuleFor(c => c.DataFinal)
                .GreaterThanOrEqualTo(DateTime.Now)
                .When(c => c.DataFinal.HasValue)
                .WithMessage("Campo {PropertyName}, se fornecido, deve ser maior ou igual à data atual. Valor atual: '{PropertyValue}'");

            
        }
        private bool BeAValidPriority(int prioridadeId)
        {
            return Enum.IsDefined(typeof(TipoPrioridadeEnum), prioridadeId);
        }
    }
}
