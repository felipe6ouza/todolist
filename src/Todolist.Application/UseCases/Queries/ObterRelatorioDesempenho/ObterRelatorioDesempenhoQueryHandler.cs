using FluentResults;
using MediatR;
using Todolist.Domain.Enum;
using Todolist.Domain.Repositories;
using Todolist.Domain.View;

namespace Todolist.Application.UseCases.Queries.ObterRelatorioDesempenho
{
    public class ObterRelatorioDesempenhoQueryHandler(IRelatorioDesempenhoRepository relatorioDesempenhoRepository, IUsuarioRepository usuarioRepository) : IRequestHandler<ObterRelatorioDesempenhoQuery, IResult<IEnumerable<RelatorioTarefasConcluidasView>>>
    {
        private readonly IRelatorioDesempenhoRepository _relatorioDesempenhoRepository = relatorioDesempenhoRepository;
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        public async Task<IResult<IEnumerable<RelatorioTarefasConcluidasView>>> Handle(ObterRelatorioDesempenhoQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorId(request.UsuarioId);

 
            if (usuario == null || usuario.FuncaoUsuarioId != (int)FuncaoUsuarioEnum.Gerente)
                return Result.Fail<IEnumerable<RelatorioTarefasConcluidasView>>("Usuário não tem permissão para visualizar o relatório");

            var relatorio = await _relatorioDesempenhoRepository.ObterRelatorioDesempenho();

            return Result.Ok(relatorio);
        }
    }
}
