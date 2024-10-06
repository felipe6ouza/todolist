using FluentResults;
using MediatR;
using Todolist.Domain.Repositories;

namespace Todolist.Application.UseCases.Commands.CriarTarefa
{

    public class CriarTarefaCommandHandler(IProjetoRepository projetoRepository, ITarefaRepository tarefaRepository) : IRequestHandler<CriarTarefaCommand, Result<int>>
    {
        private readonly IProjetoRepository _projetoRepository = projetoRepository;
        private readonly ITarefaRepository _tarefaRepository = tarefaRepository;

        public async Task<Result<int>> Handle(CriarTarefaCommand request, CancellationToken cancellationToken)
        {

            var projeto = await _projetoRepository.GetById(request.ProjetoId);

            if (projeto == null)
                return Result.Fail<int>("O Projeto não existe");

            var tarefa = projeto.AdicionarTarefa(request.Nome, request.PrioridadeId, request.AutorId, request.DataFinal, request.Descricao, request.ResponsavelId);

            _tarefaRepository.Add(tarefa);
            _projetoRepository.Update(projeto);

            await _projetoRepository.UnitOfWork.Commit();

            return Result.Ok(tarefa.Id);
        }
    }
}
