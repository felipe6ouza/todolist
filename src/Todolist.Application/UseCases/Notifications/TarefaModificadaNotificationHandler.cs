using MediatR;
using System.Text.Json;
using Todolist.Domain.Entities;
using Todolist.Domain.Repositories;

namespace Todolist.Application.UseCases.Notifications
{
    public class TarefaModificadaNotificationHandler(ITarefaRepository tarefaRepository) : INotificationHandler<TarefaModificadaNotification>
    {
        private readonly ITarefaRepository _tarefaRepository = tarefaRepository;

        public async Task Handle(TarefaModificadaNotification notification, CancellationToken cancellationToken)
        {
            var modificacoesJson = JsonSerializer.Serialize(new
            {
                notification.TarefaEstadoAnterior,
                notification.TarefaEstadoAtual,
            });

            var historico = new HistoricoTarefa(
                notification.TarefaEstadoAtual.Id,
                modificacoesJson,
                notification.DataHora,
                notification.UsuarioId
            );

            await _tarefaRepository.AdicionarHistoricoTarefa(historico);
        }
    }

}
