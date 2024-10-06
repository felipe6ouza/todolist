using FluentValidation;

namespace Todolist.Application.UseCases.Queries.ListarProjetosUsuario
{

    public class ListarProjetosUsuarioQueryValidator : AbstractValidator<ListarProjetosUsuarioQuery>
    {
        public ListarProjetosUsuarioQueryValidator()
        {
            RuleFor(c => c.UsuarioId)
             .GreaterThan(0)
            .WithMessage("Campo {PropertyName} deve ser maior que 0. Valor atual: '{PropertyValue}'.");

        }
    }
}
