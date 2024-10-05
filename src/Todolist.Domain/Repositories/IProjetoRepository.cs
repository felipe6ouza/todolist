using Todolist.Domain.Aggregates;
using Todolist.Domain.Shared;

namespace Todolist.Domain.Repositories
{

    public interface IProjetoRepository : IRepository<Projeto>
    {
        Task<Projeto?> GetById(Guid id);
        Task<IEnumerable<Projeto>> GetAll();
        void Add(Projeto project);
        void Update(Projeto project);
        void Remove(Projeto project);
    }
}
