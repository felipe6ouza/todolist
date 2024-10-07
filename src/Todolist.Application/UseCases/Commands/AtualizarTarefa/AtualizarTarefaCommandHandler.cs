using FluentResults;
using MediatR;
using Todolist.Domain.Repositories;

namespace Todolist.Application.UseCases.Commands.AtualizarTarefa
{
    public class AtualizarTarefaCommandHandler(ITarefaRepository tarefaRepository) : IRequestHandler<AtualizarTarefaCommand, Result>
    {
        private readonly ITarefaRepository _tarefaRepository = tarefaRepository;

        public async Task<Result> Handle(AtualizarTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.GetById(request.TarefaId);
            
            if (tarefa == null)
                return Result.Fail("A tarefa não existe");

            tarefa.AtualizarNome(request.Nome);
            tarefa.AtualizarDescricao(request.Descricao);
            tarefa.AtualizarDataFinal(request.DataFinal);
            tarefa.AtualizarResponsavel(request.ResponsavelId);
            tarefa.AtualizarStatus(request.StatusTarefaId);

            _tarefaRepository.Update(tarefa);
            await _tarefaRepository.UnitOfWork.Commit();

            return Result.Ok();
        }
    }

}
