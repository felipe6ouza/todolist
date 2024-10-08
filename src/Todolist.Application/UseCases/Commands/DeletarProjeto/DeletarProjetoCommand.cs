using FluentResults;
using MediatR;
using Todolist.Domain.Shared;

namespace Todolist.Application.UseCases.Commands.DeletarProjeto
{
    public class DeletarProjetoCommand : IRequest<Result>, ICommandBase
    {
        public int ProjetoId { get; set; }
    }

}
