using AutoMapper;
using FluentResults;
using MediatR;
using System.Text.Json;
using Todolist.Application.UseCases.Queries.ObterDetalhesTarefa;
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
            var tarefa = await _tarefaRepository.GetById(request.TarefaId);
            
            if (tarefa == null)
                return Result.Fail("A tarefa não existe");

            var snapshotTarefaAnteriorModificacacoes = _mapper.Map<DetalhesTarefaViewModel>(tarefa);


            tarefa.AtualizarNome(request.Nome);
            tarefa.AtualizarDescricao(request.Descricao);
            tarefa.AtualizarDataFinal(request.DataFinal);
            tarefa.AtualizarResponsavel(request.ResponsavelId);
            tarefa.AtualizarStatus(request.StatusTarefaId);

            _tarefaRepository.Update(tarefa);

            var tarefaEstadoAtual = _mapper.Map<DetalhesTarefaViewModel>(tarefa);

            var modificacoesJson = JsonSerializer.Serialize(new
            {
                TarefaEstadoAnterior = snapshotTarefaAnteriorModificacacoes,
                TarefaEstadoAtual = tarefaEstadoAtual
            });

            await _mediator.Publish(new TarefaModificadaNotification(tarefa, modificacoesJson, DateTime.UtcNow, 1));

            await _tarefaRepository.UnitOfWork.Commit();

            return Result.Ok();
        }
    }

}
