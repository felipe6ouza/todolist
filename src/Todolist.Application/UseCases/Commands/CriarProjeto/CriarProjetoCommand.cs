using FluentResults;
using MediatR;

namespace Todolist.Application.UseCases.Commands.CriarProjeto
{
    public class CriarProjetoCommand : IRequest<IResult<int>>
    {
        public int AutorId { get; set; }
        public required string Nome { get; set; }
        public bool Favorito { get; set; }

    }
}
