using Todolist.Domain.Shared;

namespace Todolist.Domain.Aggregates
{
    public class Usuario : IAggregateRoot
    {
        protected Usuario() { }
        
        public Usuario (string nome, string sobrenome, DateTime dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }

        public int? Id { get; private set; }
        public string? Nome { get; private set; }
        public string? Sobrenome { get; private set; } 
        public DateTime? DataNascimento { get; private set; }

        public void AtualizarNomeUsuario(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

    }

}
