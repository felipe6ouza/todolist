using FluentResults;
using MediatR;
using Todolist.Domain.Shared;

namespace Todolist.Application.UseCases.Commands.AtualizarTarefa
{
    public class AtualizarTarefaCommand : IRequest<Result>, ICommandBase
    {
        public int TarefaId { get; set; }
        public string? Nome { get; set; }
        public int? PrioridadeId { get; set; }
        public DateTime? DataFinal { get; set; }
        public string? Descricao { get; set; }
        public int? StatusTarefaId { get; set; }
        public int? ResponsavelId { get; set; }

    }

}
