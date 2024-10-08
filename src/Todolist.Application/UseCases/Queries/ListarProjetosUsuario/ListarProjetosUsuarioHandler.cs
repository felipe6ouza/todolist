using AutoMapper;
using MediatR;
using Todolist.Application.ViewModel;
using Todolist.Domain.Repositories;

namespace Todolist.Application.UseCases.Queries.ListarProjetosUsuario
{
    public class ListarProjetosUsuarioHandler(IProjetoRepository projetoRepository, IMapper mapper) : IRequestHandler<ListarProjetosUsuarioQuery, IEnumerable<ProjetoViewModel>>
    {
        private readonly IProjetoRepository _projetoRepository = projetoRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ProjetoViewModel>> Handle(ListarProjetosUsuarioQuery request, CancellationToken cancellationToken)
        {
            var projetos = await _projetoRepository.BuscarProjetosUsuario(request.UsuarioId);

            return _mapper.Map<IEnumerable<ProjetoViewModel>>(projetos);
        }
    }
}
