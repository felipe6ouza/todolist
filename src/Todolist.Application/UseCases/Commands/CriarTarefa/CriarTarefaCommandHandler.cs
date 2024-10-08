using FluentResults;
using MediatR;
using Todolist.Domain.Repositories;

namespace Todolist.Application.UseCases.Commands.CriarTarefa
{

    public class CriarTarefaCommandHandler(IProjetoRepository projetoRepository, ITarefaRepository tarefaRepository) : IRequestHandler<CriarTarefaCommand, IResult<int>>
    {
        private readonly IProjetoRepository _projetoRepository = projetoRepository;
        private readonly ITarefaRepository _tarefaRepository = tarefaRepository;

        public async Task<IResult<int>> Handle(CriarTarefaCommand request, CancellationToken cancellationToken)
        {

            var projeto = await _projetoRepository.ObterPorId(request.ProjetoId);

            if (projeto == null)
                return Result.Fail<int>("O Projeto não existe");

            var tarefa = projeto.AdicionarTarefa(request.Nome, request.PrioridadeId, request.AutorId, request.DataFinal, request.Descricao!, request.ResponsavelId);

            _tarefaRepository.Criar(tarefa);
            _projetoRepository.Atualizar(projeto);

            await _projetoRepository.UnitOfWork.Commit();

            return Result.Ok(tarefa.Id);
        }
    }
}
