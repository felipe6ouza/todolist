﻿using MediatR;
using Todolist.Application.ViewModel;
using Todolist.Domain.Shared;

namespace Todolist.Application.UseCases.Queries.ListarProjetosUsuario
{
    public class ListarProjetosUsuarioQuery : IRequest<IEnumerable<ProjetoViewModel>>, ICommandBase
    {
        public int UsuarioId { get; set; }
    }
}
