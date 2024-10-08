using Todolist.Domain.Aggregates;
using Todolist.Domain.Shared;

namespace Todolist.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario?> ObterPorId(int id);
        void Criar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Remover(Usuario usuario);
    }
}
