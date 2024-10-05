using Todolist.Domain.Shared;
using Todolist.Domain.ValueObjects;

namespace Todolist.Domain.Aggregates
{
    public class Projeto(string name, Usuario usuarioAutor, CorHexadecimal cor, bool marcadoComoFavorito = false, bool ativo = true) : IAggregateRoot
    {
        public int ProjetoId { get; private set; }
        public Usuario Autor { get; private set; } = usuarioAutor;
        public string Nome { get; private set; } = name;
        public StatusProjeto Status { get; private set; } = new StatusProjeto(marcadoComoFavorito, ativo);
        public CorHexadecimal Cor { get; private set; } = cor;

        private readonly List<Tarefa> _tarefas = new();
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
