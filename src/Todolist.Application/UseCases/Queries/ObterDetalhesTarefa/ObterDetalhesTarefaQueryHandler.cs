using AutoMapper;
using FluentResults;
using MediatR;
using Todolist.Domain.Aggregates;
using Todolist.Domain.Repositories;

namespace Todolist.Application.UseCases.Queries.ObterDetalhesTarefa
{
   
    public class ObterDetalhesTarefaQueryHandler(ITarefaRepository tarefaRepository, IMapper mapper) : IRequestHandler<ObterDetalhesTarefaQuery, IResult<DetalhesTarefaViewModel>>
    {
        private readonly ITarefaRepository _tarefaRepository = tarefaRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IResult<DetalhesTarefaViewModel>> Handle(ObterDetalhesTarefaQuery request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.GetById(request.TarefaId);

            if (tarefa == null)
                return Result.Fail<DetalhesTarefaViewModel>("Tarefa não existe");

            var detalhesTarefaViewModel = _mapper.Map<DetalhesTarefaViewModel>(tarefa);

            return Result.Ok(detalhesTarefaViewModel);
        }
    }
}
