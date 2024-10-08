using AutoMapper;
using FluentResults;
using MediatR;
using Todolist.Application.UseCases.Notifications;
using Todolist.Application.ViewModel;
using Todolist.Domain.Repositories;

namespace Todolist.Application.UseCases.Commands.AdicionarComentarioTarefa
{
    public class AdicionarComentarioTarefaCommandHandler(ITarefaRepository tarefaRepository, IMapper mapper, IMediator mediator) : IRequestHandler<AdicionarComentarioTarefaCommand, IResult<int>>
    {
        private readonly ITarefaRepository _tarefaRepository = tarefaRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IMediator _mediator = mediator;

        public async Task<IResult<int>> Handle(AdicionarComentarioTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.ObterPorId(request.TarefaId);

            var snapshotTarefaAnteriorModificacacoes = _mapper.Map<DetalhesTarefaViewModel>(tarefa);

            if (tarefa == null)
                Result.Fail("A Tarefa não existe");

            var comentario = tarefa!.AdicionarComentario(request.Descricao, request.AutorId);

            var snapshotTarefaEstadoAtual = _mapper.Map<DetalhesTarefaViewModel>(tarefa);

            _tarefaRepository.Atualizar(tarefa);

            await _mediator.Publish(new TarefaModificadaNotification(snapshotTarefaEstadoAtual, snapshotTarefaAnteriorModificacacoes, request.AutorId), cancellationToken);

            await _tarefaRepository.UnitOfWork.Commit();

            return Result.Ok(comentario.Id);
        }
    }
}
