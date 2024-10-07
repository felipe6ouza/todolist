using FluentResults;
using MediatR;
using System.Collections.Generic;
using Todolist.Domain.Repositories;
using Todolist.Domain.View;

namespace Todolist.Application.UseCases.Queries.ObterRelatorioDesempenho
{
    public class ObterRelatorioDesempenhoQueryHandler(IRelatorioDesempenhoRepository relatorioDesempenhoRepository) : IRequestHandler<ObterRelatorioDesempenhoQuery, IResult<IEnumerable<RelatorioTarefasConcluidasView>>>
    {
        private readonly IRelatorioDesempenhoRepository _relatorioDesempenhoRepository = relatorioDesempenhoRepository;

        public async Task<IResult<IEnumerable<RelatorioTarefasConcluidasView>>> Handle(ObterRelatorioDesempenhoQuery request, CancellationToken cancellationToken)
        {
            return Result.Ok(await _relatorioDesempenhoRepository.ObterRelatorioDesempenho());
        }
    }
}
