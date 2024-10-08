using FluentResults;
using MediatR;
using Todolist.Domain.Shared;

namespace Todolist.Application.UseCases.Commands.DeletarTarefa
{
    public class DeletarTarefaCommand : IRequest<Result>, ICommandBase
    {
        public int TarefaId {get; set;}
    }
}
