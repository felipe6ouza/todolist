using FluentResults;
using MediatR;
using Todolist.Domain.Shared;

namespace Todolist.Application.UseCases.Commands.CriarTarefa
{
    public class CriarTarefaCommand : IRequest<IResult<int>>, ICommandBase
    {
        public int ProjetoId { get; set; }
        public int PrioridadeId { get; set; }
        public int AutorId { get; set; }
        public int? ResponsavelId { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataFinal { get; set; }
    }
}
