using Todolist.Domain.Entities;
using Todolist.Domain.Shared;

namespace Todolist.Domain.Aggregates
{
    public class Usuario : IAggregateRoot
    {
        
        public int? Id { get; private set; }
        public string? Nome { get; private set; }
        public string? Sobrenome { get; private set; } 
        public DateTime? DataNascimento { get; private set; }
        public int? FuncaoUsuarioId { get; set; }
        public FuncaoUsuario? FuncaoUsuario { get; set; }

        public Usuario() { }

        public Usuario(string nome, string sobrenome, DateTime dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }

        public Usuario(string nome, string sobrenome, DateTime dataNascimento, int funcaoUsuarioId, int id)
          : this(nome, sobrenome, dataNascimento) 
        {
            Id = id;
            FuncaoUsuarioId = funcaoUsuarioId;
        }
        public void AtualizarNomeUsuario(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

    }
}
