using Todolist.Domain.Shared;

namespace Todolist.Domain.Aggregates
{
    public class Usuario(string nome, string sobrenome, DateTime dataNascimento) : IAggregateRoot
    {
        public int UsuarioId { get; private set; }
        public string Nome { get; private set; } = nome;
        public string Sobrenome { get; private set; } = sobrenome;
        public DateTime DataNascimento { get; private set; } = dataNascimento;

        public void AtualizarNomeUsuario(string nome, string dataNascimento)
        {
            Nome = nome;
            Sobrenome = dataNascimento;
        }
    }

}
