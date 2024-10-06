using FluentResults;
using MediatR;

namespace Todolist.Application.UseCases.Commands.CriarProjeto
{
    public class CriarProjetoCommand : IRequest<Result<int>>
    {
        public int AutorId { get; set; }
        public string Nome { get; set; }
        public string CorHexadecimal { get; set; }
        public bool Favorito { get; set; }

    }
}
