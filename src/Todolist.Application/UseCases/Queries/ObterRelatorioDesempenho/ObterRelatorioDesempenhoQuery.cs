using FluentResults;
using MediatR;
using Todolist.Domain.View;

namespace Todolist.Application.UseCases.Queries.ObterRelatorioDesempenho
{
    public class ObterRelatorioDesempenhoQuery : IRequest<IResult<IEnumerable<RelatorioTarefasConcluidasView>>>
    {
        public int UsuarioId { get; set; }
    }
}
