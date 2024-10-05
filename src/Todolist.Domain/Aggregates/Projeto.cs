using Todolist.Domain.Shared;
using Todolist.Domain.ValueObjects;

namespace Todolist.Domain.Aggregates
{
    public class Projeto : IAggregateRoot
    {
        protected Projeto()
        {

        }

        public Projeto(string nome, Usuario autor, CorHexadecimal cor, bool marcadoComoFavorito = false)
        {
            Nome = nome;
            Autor = autor;
            Cor = cor;
            Status =  new StatusProjeto(marcadoComoFavorito, true);
        }
      
        public int Id { get; private set; }
        public Usuario? Autor { get; private set; } 
        public string? Nome { get; private set; } 
        public StatusProjeto? Status { get; private set; }
        public CorHexadecimal? Cor { get; private set; }

        private readonly List<Tarefa> _tarefas = [];
        public IReadOnlyCollection<Tarefa> Tarefas => _tarefas;

        public void AdicionarTarefa(Tarefa tarefa)
        {
            if (_tarefas.Count == 20)
               throw new DomainException("Um projeto só pode ter no máximo 20 tarefas");

            _tarefas.Add(tarefa);
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
