﻿using FluentResults;
using MediatR;
using Todolist.Application.ViewModel;

namespace Todolist.Application.UseCases.Queries.ObterDetalhesTarefa
{
    public class ObterDetalhesTarefaQuery : IRequest<IResult<DetalhesTarefaViewModel>>
    {
        public int TarefaId { get; set; }
    }
}
