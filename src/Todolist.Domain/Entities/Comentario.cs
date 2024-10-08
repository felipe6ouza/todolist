using Todolist.Domain.Aggregates;

namespace Todolist.Domain.Entities
{
    public class Comentario(int tarefaId, int autorId, string descricao)
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; } = descricao;
        public int TarefaId { get; private set; } = tarefaId;
        public int AutorId { get; private set; } = autorId;
        public Tarefa? Tarefa { get; private set; }
        public Usuario? Autor { get; private set; }

        public void AtualizarComentario(string novaDescricao)
        {
            Descricao = novaDescricao;
        }
    }
}
