using Todolist.Domain.Aggregates;

namespace Todolist.Domain.Entities
{
    public class FuncaoUsuario
    {
        protected FuncaoUsuario()
        {
           
        }
        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Usuario> Usuarios { get; set; } // Relação inversa

    }
}
