using Todolist.Domain.Aggregates;
using Todolist.Domain.Shared;

namespace Todolist.Domain.Repositories
{

    public interface IProjetoRepository : IRepository<Projeto>
    {
        Task<Projeto?> ObterPorId(int id);
        Task<IEnumerable<Projeto>> BuscarProjetosUsuario(int id);
        void Criar(Projeto project);
        void Atualizar(Projeto project);
        void Remover(Projeto project);
    }
}
