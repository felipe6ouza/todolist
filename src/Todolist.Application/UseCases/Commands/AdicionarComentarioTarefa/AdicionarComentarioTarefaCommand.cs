using FluentResults;
using MediatR;
using System.Text.Json.Serialization;
using Todolist.Domain.Shared;

namespace Todolist.Application.UseCases.Commands.AdicionarComentarioTarefa
{
    public class AdicionarComentarioTarefaCommand : IRequest<IResult<int>>, ICommandBase
    {
        [JsonIgnore]
        public int TarefaId { get; set; }
        public int AutorId { get; set; }
        public required string Descricao { get; set; }
    }
}
