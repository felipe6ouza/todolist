using FluentResults;
using MediatR;
using Todolist.Domain.Aggregates;
using Todolist.Domain.Repositories;
using Todolist.Domain.ValueObjects;

namespace Todolist.Application.UseCases.Commands.CriarProjeto
{
    public class CriarProjetoCommandHandler(IProjetoRepository projetoRepository, IUsuarioRepository autorRepository) : IRequestHandler<CriarProjetoCommand, IResult<int>>
    {
        private readonly IProjetoRepository _projetoRepository = projetoRepository;

        private readonly IUsuarioRepository _usuarioRepository = autorRepository;

        public async Task<IResult<int>> Handle(CriarProjetoCommand request, CancellationToken cancellationToken)

        {
            var autor = await _usuarioRepository.ObterPorId(request.AutorId);


            if (autor == null)
            {
                return Result.Fail<int>("Autor não é válido.");
            }

            var projeto = new Projeto(request.Nome, autor, request.Favorito);
          
            _projetoRepository.Criar(projeto); 

            await _projetoRepository.UnitOfWork.Commit();

            return Result.Ok(projeto.Id);
        }
    }

}
