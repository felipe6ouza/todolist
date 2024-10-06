using Todolist.Domain.Entities;
using Todolist.Domain.Shared;
using Todolist.Domain.ValueObjects;

namespace Todolist.Domain.Aggregates
{
    public class Tarefa : IAggregateRoot
    {
        public Tarefa() { }
        
        public Tarefa(string nome, Projeto projeto, TipoPrioridade prioridade, Usuario autor, TimelineTarefa timelineTarefa, string? descricao)
        {
            Nome = nome;
            Projeto = projeto;
            Prioridade = prioridade;
            Autor = autor;
            TimelineTarefa = timelineTarefa;
            Descricao = descricao;
            StatusTarefa = (int)StatusTarefaEnum.Pendente;
        }
        public int Id { get; private set; }
        public int ProjetoId { get; private set; }
        public Projeto? Projeto { get; private set; }
        public int PrioridadeId { get; private set; }  
        public TipoPrioridade? Prioridade { get; private set; } 
        public Usuario? Autor { get; private set; }
        public Usuario? Responsavel { get; private set; }
        public string? Nome { get; private set; } 
        public string? Descricao { get; private set; } 
        public TimelineTarefa? TimelineTarefa { get; private set; }
        public int StatusTarefa { get; private set; }


        private readonly List<Comentario> _comentarios = [];
        public IReadOnlyCollection<Comentario> Comentarios => _comentarios;

        public void AdicionarComentario(string descricao, int usuarioId)
        {
            var comentario = new Comentario(Id, usuarioId, descricao);
            _comentarios.Add(comentario);
        }

        public void AdicionarResponsavel(Usuario usuarioResponsavel)
        {
            Responsavel = usuarioResponsavel;
        }

    }

}
