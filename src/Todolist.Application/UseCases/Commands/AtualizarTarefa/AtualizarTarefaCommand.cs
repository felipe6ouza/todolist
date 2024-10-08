using FluentResults;
using MediatR;
using System.Text.Json.Serialization;
using Todolist.Domain.Shared;

namespace Todolist.Application.UseCases.Commands.AtualizarTarefa
{
    public class AtualizarTarefaCommand : IRequest<Result>, ICommandBase
    {
        [JsonIgnore]
        public int TarefaId { get; set; }
        public int UsuarioId { get; set; }
        public string? Nome { get; set; }
        public int? PrioridadeId { get; set; }
        public DateTime? DataFinal { get; set; }
        public string? Descricao { get; set; }
        public int? StatusTarefaId { get; set; }
        public int? ResponsavelId { get; set; }


    }

}
