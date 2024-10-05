using Microsoft.EntityFrameworkCore;
using Todolist.Domain.Aggregates;
using Todolist.Domain.Entities;
using Todolist.Domain.Shared;
using Todolist.Infrastructure.Mappings;
using Tarefa = Todolist.Domain.Aggregates.Tarefa;

namespace Todolist.Infrastructure.Context
{

    public class TodolistDbContext(DbContextOptions<TodolistDbContext> options) : DbContext(options), IUnitOfWork
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<TipoPrioridade> TiposPrioridade { get; set; }

        // Configuração das entidades usando Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new ProjetoMapping());
            modelBuilder.ApplyConfiguration(new TarefaMapping());
            modelBuilder.ApplyConfiguration(new ComentarioMapping());
        }

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 1;
        }



    }
}
