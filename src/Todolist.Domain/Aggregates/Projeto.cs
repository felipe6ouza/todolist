using Todolist.Domain.Shared;
using Todolist.Domain.ValueObjects;

namespace Todolist.Domain.Aggregates
{
    public class Projeto : IAggregateRoot
    {
        const int NUMERO_MAXIMO_TAREFAS = 20;
       
        public int Id { get; private set; }
        public string? Nome { get; private set; } 
        public StatusProjeto? Status { get; private set; }
        public Usuario? Autor { get; private set; }

        private readonly List<Tarefa> _tarefas = [];
        public IReadOnlyCollection<Tarefa> Tarefas => _tarefas;

        protected Projeto() { }
    
        public Projeto(string nome, Usuario autor, bool marcadoComoFavorito = false)
        {
            Nome = nome;
            Autor = autor;
            Status = new StatusProjeto(marcadoComoFavorito, true);
        }

        public Tarefa AdicionarTarefa(string nome, int prioridadeId, int autorId, DateTime? dataFinal, string descricao, int? responsavelId = null)
        {
            if (Tarefas.Count >= NUMERO_MAXIMO_TAREFAS)
                throw new DomainException("Numero máximo de Tarefas Excedido");

            var tarefa = new Tarefa(nome, this.Id, prioridadeId, autorId, new TimelineTarefa(dataFinal), descricao, responsavelId);
            
            _tarefas.Add(tarefa);

            return tarefa;
        }

        public void AtualizarStatus(bool marcadoComoFavorito, bool ativo)
        {
            Status = new StatusProjeto(marcadoComoFavorito, ativo);
        }
        public bool VerificaSeProjetoPodeSerRemovido()
        {
            return _tarefas.Count == 0;
        }
    }

}
