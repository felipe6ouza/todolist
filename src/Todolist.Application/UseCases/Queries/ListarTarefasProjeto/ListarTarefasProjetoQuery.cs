using FluentResults;
using MediatR;

namespace Todolist.Application.UseCases.Queries.ListarTarefasProjeto
{
    public class ListarTarefasProjetoQuery : IRequest<IResult<IEnumerable<TarefaViewModel>>>
    {
        public int ProjetoId { get; set; }
    }
}
