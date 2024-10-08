using Todolist.Domain.Aggregates;

namespace Todolist.Domain.Entities
{
    public class FuncaoUsuario
    {
        protected FuncaoUsuario() { }
       
        public int? Id { get; set; }
        public string? Descricao { get; set; }

        public List<Usuario>? Usuarios { get; set; }

    }
}
