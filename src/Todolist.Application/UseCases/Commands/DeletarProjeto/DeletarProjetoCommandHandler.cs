using FluentResults;
using MediatR;
using Todolist.Domain.Repositories;

namespace Todolist.Application.UseCases.Commands.DeletarProjeto
{
    public class DeletarProjetoHandler(IProjetoRepository projetoRepository) : IRequestHandler<DeletarProjetoCommand, Result>
    {
        private readonly IProjetoRepository _projetoRepository = projetoRepository;

        public async Task<Result> Handle(DeletarProjetoCommand request, CancellationToken cancellationToken)
        {
            var projeto = await _projetoRepository.ObterPorId(request.ProjetoId);

            if (projeto == null)
                return Result.Fail("ProjetoId inválido");

            if (!projeto.VerificaSeProjetoPodeSerRemovido())
                return Result.Fail("O Projeto não pode ser removido porque existem tarefas associadas");
   

            _projetoRepository.Remover(projeto);
            await _projetoRepository.UnitOfWork.Commit();

            return Result.Ok();
        }
    }

}
