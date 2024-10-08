using FluentResults;
using MediatR;
using Todolist.Application.ViewModel;
using Todolist.Domain.Repositories;

namespace Todolist.Application.UseCases.Queries.ListarUsuarios
{
    internal class ListarUsuariosQueryHandler(IUsuarioRepository usuarioRepository) : IRequestHandler<ListarUsuariosQuery, IResult<IEnumerable<UsuarioViewModel>>>
    {

        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        public async Task<IResult<IEnumerable<UsuarioViewModel>>> Handle(ListarUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.ObterTodos();
            
            if (usuarios == null || !usuarios.Any())
                return Result.Fail<IEnumerable<UsuarioViewModel>>("Nenhum usuário encontrado.");

            var usuariosViewModel = usuarios.Select(u => new UsuarioViewModel
            {
                Id = u.Id,
                Nome = u.Nome!
            }).ToList();

            return Result.Ok(usuariosViewModel);
        }
    }
}
