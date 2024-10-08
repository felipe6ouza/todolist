using Todolist.Domain.Aggregates;
using Todolist.Domain.Entities;
using Todolist.Domain.Shared;
namespace Todolist.Domain.Repositories
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Task<Tarefa?> ObterPorId(int id);
        void Criar(Tarefa tarefa);
        void Atualizar(Tarefa tarefa);
        void Remover(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> ObterTarefasPorProjetoId(int projetoId);
        Task AdicionarHistoricoTarefa(HistoricoTarefa tarefa);
    }
}
