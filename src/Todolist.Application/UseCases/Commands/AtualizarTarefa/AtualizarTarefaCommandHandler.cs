using AutoMapper;
using FluentResults;
using MediatR;
using Todolist.Application.UseCases.Notifications;
using Todolist.Application.ViewModel;
using Todolist.Domain.Repositories;

namespace Todolist.Application.UseCases.Commands.AtualizarTarefa
{
    public class AtualizarTarefaCommandHandler(ITarefaRepository tarefaRepository, IMediator mediator, IMapper mapper) : IRequestHandler<AtualizarTarefaCommand, Result>
    {
        private readonly ITarefaRepository _tarefaRepository = tarefaRepository;
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        public async Task<Result> Handle(AtualizarTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.ObterPorId(request.TarefaId);
            
            if (tarefa == null)
                return Result.Fail("A tarefa não existe");

            var snapshotTarefaAnteriorModificacacoes = _mapper.Map<DetalhesTarefaViewModel>(tarefa);

            tarefa.AtualizarNome(request.Nome);
            tarefa.AtualizarDescricao(request.Descricao);
            tarefa.AtualizarDataFinal(request.DataFinal);
            tarefa.AtualizarResponsavel(request.ResponsavelId);
            tarefa.AtualizarStatus(request.StatusTarefaId);

            _tarefaRepository.Atualizar(tarefa);

            var snapshotTarefaEstadoAtual = _mapper.Map<DetalhesTarefaViewModel>(tarefa);

            await _mediator.Publish(new TarefaModificadaNotification(snapshotTarefaAnteriorModificacacoes, snapshotTarefaEstadoAtual, request.UsuarioId), cancellationToken);

            await _tarefaRepository.UnitOfWork.Commit();

            return Result.Ok();
        }
    }

}
