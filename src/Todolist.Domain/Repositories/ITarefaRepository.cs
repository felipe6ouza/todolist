using Todolist.Domain.Aggregates;
using Todolist.Domain.Shared;
namespace Todolist.Domain.Repositories
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Task<Tarefa?> GetById(int id);
        Task<IEnumerable<Tarefa>> GetAll();
        void Add(Tarefa tarefa);
        void Update(Tarefa tarefa);
        void Remove(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> ObterTarefasPorProjetoId(int projetoId);

    }
}
