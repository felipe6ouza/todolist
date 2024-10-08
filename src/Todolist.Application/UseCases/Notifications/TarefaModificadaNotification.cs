using MediatR;
using Todolist.Application.ViewModel;

namespace Todolist.Application.UseCases.Notifications
{
    public class TarefaModificadaNotification(DetalhesTarefaViewModel tarefaEstadoAtual, DetalhesTarefaViewModel tarefaEstadoAnterior, int usuarioId) : INotification
    {
        public DetalhesTarefaViewModel TarefaEstadoAtual { get; } = tarefaEstadoAtual;
        public DetalhesTarefaViewModel TarefaEstadoAnterior { get; } = tarefaEstadoAnterior;
        public int UsuarioId { get; } = usuarioId;
        public DateTime DataHora { get; } = DateTime.Now;


    }

}
