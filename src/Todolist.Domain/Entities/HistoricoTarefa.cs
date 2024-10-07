using Todolist.Domain.Aggregates;

namespace Todolist.Domain.Entities
{
    public class HistoricoTarefa
    {
        public int Id { get; private set; }
        public int TarefaId { get; private set; }
        public int UsuarioId { get; private set; }

        public string Modificacoes { get; private set; }  
        public DateTime DataModificacao { get; private set; }

        public virtual Tarefa Tarefa { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public HistoricoTarefa(int tarefaId, string modificacoes, DateTime dataModificacao, int usuarioId)
        {
            TarefaId = tarefaId;
            Modificacoes = modificacoes;
            DataModificacao = dataModificacao;
            UsuarioId = usuarioId;
        }

        protected HistoricoTarefa() { }
        
    }

}
