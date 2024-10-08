using MediatR;
using Todolist.Domain.Aggregates;

namespace Todolist.Application.UseCases.Commands.AtualizarTarefa
{
    public class TarefaModificadaNotification : INotification
    {
        public Tarefa Tarefa { get; }
        public string ModificacoesJson { get; }
        public DateTime DataHora { get; }
        public int UsuarioId { get; }

        public TarefaModificadaNotification(Tarefa tarefa, string modificacoesJson, DateTime dataHora, int usuarioId)
        {
            Tarefa = tarefa;
            ModificacoesJson = modificacoesJson;
            DataHora = dataHora;
            UsuarioId = usuarioId;
        }
    }

}
