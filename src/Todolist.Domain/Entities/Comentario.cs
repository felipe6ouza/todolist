using Todolist.Domain.Aggregates;

namespace Todolist.Domain.Entities
{
    public class Comentario
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public int TarefaId { get; private set; } 
        public Tarefa? Tarefa { get; private set; } 
        public int AutorId { get; private set; }
        public Usuario? Autor { get; private set; }

        public Comentario(int tarefaId, int autorId, string descricao)
        {
            TarefaId = tarefaId; 
            AutorId = autorId;
            Descricao = descricao;
        }
        public void AtualizarComentario(string novaDescricao)
        {
            Descricao = novaDescricao;
        }
    }
}
