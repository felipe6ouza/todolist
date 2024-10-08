using MediatR;
using Todolist.Domain.Entities;
using Todolist.Domain.Repositories;

namespace Todolist.Application.UseCases.Commands.AtualizarTarefa
{
    public class TarefaModificadaNotificationHandler(ITarefaRepository tarefaRepository) : INotificationHandler<TarefaModificadaNotification>
    {
        private readonly ITarefaRepository _tarefaRepository = tarefaRepository;

        public async Task Handle(TarefaModificadaNotification notification, CancellationToken cancellationToken)
        {
            var historico = new HistoricoTarefa(
                notification.Tarefa.Id,
                notification.ModificacoesJson,
                notification.DataHora,
                notification.UsuarioId
            );

            await _tarefaRepository.AdicionarHistoricoTarefa(historico);
        }
    }

}
