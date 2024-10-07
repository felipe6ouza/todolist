using Todolist.Domain.Aggregates;
using Todolist.Domain.Shared;

namespace Todolist.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario?> ObterPorId(int id);
        Task<IEnumerable<Usuario>> GetAll();
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Remove(Usuario usuario);
    }
}
