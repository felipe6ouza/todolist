using Todolist.Domain.Entities;
using Todolist.Domain.Shared;
using Todolist.Domain.ValueObjects;

namespace Todolist.Domain.Aggregates
{
    public class Tarefa(string nome, Projeto projeto, TipoPrioridade prioridade, Usuario autor, TemposDaTarefa temposdaTarefa, string? descricao = null) : IAggregateRoot
    {
        public int TarefaId { get; private set; }
        public Projeto Projeto { get; private set; } = projeto;
        public TipoPrioridade Prioridade { get; private set; } = prioridade;
        public Usuario Autor { get; private set; } = autor;
        public Usuario? Responsavel { get; private set; }
        public string Nome { get; private set; } = nome;
        public string? Descricao { get; private set; } = descricao;
        public TemposDaTarefa TemposdaTarefa { get; private set; } = temposdaTarefa;

        private readonly List<Comentario> _comentarios = new();

        public IReadOnlyCollection<Comentario> Comments => _comentarios;

        public void AdicionarResponsavel(Usuario usuarioResponsavel)
        {
            Responsavel = usuarioResponsavel;
        }

        public void AdicionarComentario(string descricao, int usuarioId)
        {
            _comentarios.Add(new Comentario(TarefaId, usuarioId, descricao));
        }
    }

}
