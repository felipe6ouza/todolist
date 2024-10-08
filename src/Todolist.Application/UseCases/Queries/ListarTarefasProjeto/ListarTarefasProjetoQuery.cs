using FluentResults;
using MediatR;
using Todolist.Application.ViewModel;

namespace Todolist.Application.UseCases.Queries.ListarTarefasProjeto
{
    public class ListarTarefasProjetoQuery : IRequest<IResult<IEnumerable<ResumoTarefaViewModel>>>
    {
        public int ProjetoId { get; set; }
    }
}
