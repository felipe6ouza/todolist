using FluentResults;
using MediatR;
using Todolist.Application.ViewModel;

namespace Todolist.Application.UseCases.Queries.ListarUsuarios
{
    public class ListarUsuariosQuery : IRequest<IResult<IEnumerable<UsuarioViewModel>>> { }
}
