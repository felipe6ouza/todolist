using FluentResults;
using MediatR;
using Todolist.Domain.Repositories;

namespace Todolist.Application.UseCases.Commands.DeletarTarefa
{
    public class DeletarTarefaCommandHandler(ITarefaRepository tarefaRepository) : IRequestHandler<DeletarTarefaCommand, Result>
    {
        private readonly ITarefaRepository _tarefaRepository = tarefaRepository;

        public async Task<Result> Handle(DeletarTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.ObterPorId(request.TarefaId);

            if(tarefa == null) 
                return Result.Fail("Tarefa não encontrada");


            _tarefaRepository.Remover(tarefa!);
            await _tarefaRepository.UnitOfWork.Commit();


            return Result.Ok();
        }
    }
}
