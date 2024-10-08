using AutoMapper;
using FluentResults;
using MediatR;
using Todolist.Application.ViewModel;
using Todolist.Domain.Repositories;

namespace Todolist.Application.UseCases.Queries.ListarTarefasProjeto
{
    public class ListarTarefasProjetoQueryHandler (IProjetoRepository projetoRepository, ITarefaRepository tarefaRepository, IMapper mapper)
        : IRequestHandler<ListarTarefasProjetoQuery, IResult<IEnumerable<ResumoTarefaViewModel>>>
    {
        private readonly IProjetoRepository _projetoRepository = projetoRepository;
        private readonly ITarefaRepository _tarefaRepository = tarefaRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IResult<IEnumerable<ResumoTarefaViewModel>>> Handle(ListarTarefasProjetoQuery request, CancellationToken cancellationToken)
        {
            var projeto = await _projetoRepository.ObterPorId(request.ProjetoId);

            if(projeto == null)
                return Result.Fail<IEnumerable<ResumoTarefaViewModel>>("Projeto Não Existe");

            var tarefas = await _tarefaRepository.ObterTarefasPorProjetoId(request.ProjetoId);

            return Result.Ok (_mapper.Map<IEnumerable<ResumoTarefaViewModel>>(tarefas));
        }

    }

}
