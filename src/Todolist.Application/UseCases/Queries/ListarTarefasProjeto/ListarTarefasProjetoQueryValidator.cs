using FluentValidation;

namespace Todolist.Application.UseCases.Queries.ListarTarefasProjeto
{
    public class ListarTarefasProjetoQueryValidator : AbstractValidator<ListarTarefasProjetoQuery>
    {
        public ListarTarefasProjetoQueryValidator()
        {
            RuleFor(c => c.ProjetoId)
            .GreaterThan(0)
            .WithMessage("Campo {PropertyName} deve ser maior que 0. Valor atual: '{PropertyValue}'.");
        }
    }
}
