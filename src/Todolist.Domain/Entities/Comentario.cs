
using Todolist.Domain.Aggregates;
using Tarefa = Todolist.Domain.Aggregates.Tarefa;

namespace Todolist.Domain.Entities
{
    public class Comentario(int tarefaId, int usuarioId, string descricao)
    {
        public int ComentarioId { get; private set; }
        public string Descricao { get; private set; } = descricao;
        public int TarefaId { get; private set; } = tarefaId;
        public Tarefa? Tarefa { get; private set; }
        public int UsuarioId { get; private set; } = usuarioId;
        public Usuario? Usuario { get; private set; }

        public void AtualizarComentario(string novaDescricacao)
        {
            Descricao = novaDescricacao;
        }
    }


}
