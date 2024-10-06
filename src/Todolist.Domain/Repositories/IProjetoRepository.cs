using Todolist.Domain.Aggregates;
using Todolist.Domain.Shared;

namespace Todolist.Domain.Repositories
{

    public interface IProjetoRepository : IRepository<Projeto>
    {
        Task<Projeto?> GetById(int id);
        Task<IEnumerable<Projeto>> GetAll();

        Task<IEnumerable<Projeto>> BuscarProjetosUsuario(int id);

        void Add(Projeto project);
        void Update(Projeto project);
        void Remove(Projeto project);
    }
}
