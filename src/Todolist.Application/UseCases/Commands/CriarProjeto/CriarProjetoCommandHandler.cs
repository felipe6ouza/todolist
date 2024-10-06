using FluentResults;
using MediatR;
using Todolist.Domain.Aggregates;
using Todolist.Domain.Repositories;
using Todolist.Domain.ValueObjects;

namespace Todolist.Application.UseCases.Commands.CriarProjeto
{
    public class CriarProjetoCommandHandler : IRequestHandler<CriarProjetoCommand, Result<int>>
    {
        private readonly IProjetoRepository _projetoRepository;

        private readonly IUsuarioRepository _usuarioRepository;

        public CriarProjetoCommandHandler(IProjetoRepository projetoRepository, IUsuarioRepository autorRepository)
        {
            _projetoRepository = projetoRepository;
            _usuarioRepository = autorRepository;
        }

        public async Task<Result<int>> Handle(CriarProjetoCommand request, CancellationToken cancellationToken)

        {
            var autor = await _usuarioRepository.GetById(request.AutorId);


            if (autor == null)
            {
                return Result.Fail<int>("Autor não é válido.");
            }

            var cor = new CorHexadecimal(request.CorHexadecimal);

            var projeto = new Projeto(request.Nome, autor, cor, request.Favorito);
          
            _projetoRepository.Add(projeto); 

            await _projetoRepository.UnitOfWork.Commit();

            return Result.Ok(projeto.Id);
        }
    }

}
