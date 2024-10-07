using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;
using Todolist.Domain.Aggregates;
using Todolist.Domain.Entities;
using Todolist.Domain.Shared;
using Todolist.Domain.ValueObjects;
using Todolist.Domain.View;
using Todolist.Infrastructure.Mappings;
using Tarefa = Todolist.Domain.Aggregates.Tarefa;

namespace Todolist.Infrastructure.Context
{

    public class TodolistDbContext(DbContextOptions<TodolistDbContext> options) : DbContext(options), IUnitOfWork
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<HistoricoTarefa> HistoricoTarefas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<TipoPrioridade> TiposPrioridade { get; set; }
        public DbSet<RelatorioTarefasConcluidasView> RelatorioTarefasConcluidas { get; set; }


        // Configuração das entidades usando Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new ProjetoMapping());
            modelBuilder.ApplyConfiguration(new TarefaMapping());
            modelBuilder.ApplyConfiguration(new ComentarioMapping());
            modelBuilder.ApplyConfiguration(new PrioridadeMapping());
            modelBuilder.ApplyConfiguration(new StatusTarefaMapping());
            modelBuilder.ApplyConfiguration(new FuncaoUsuarioMapping());
            modelBuilder.ApplyConfiguration(new HistoricoTarefaMapping());


            modelBuilder.Entity<RelatorioTarefasConcluidasView>()
               .HasNoKey() 
               .ToView("vwRelatorioDesempenho");
        }

        public async Task<bool> Commit()
        {
           if(ChangeTracker.Entries<Tarefa>().Any(e => e.State == EntityState.Modified))
           {
               await GerarHistoricoAsync();
           }
            return await SaveChangesAsync() > 1;
        }

        private async Task GerarHistoricoAsync()
        {
            var historicos = new List<HistoricoTarefa>();

            foreach (var entry in ChangeTracker.Entries<Tarefa>()
                         .Where(e => e.State == EntityState.Modified))
            {
                var modificacoes = CapturarModificacoes(entry);


                var modificacoesJson = JsonSerializer.Serialize(modificacoes);

                if (modificacoes.Any())
                {
                    var historico = new HistoricoTarefa(
                        entry.Entity.Id,
                        modificacoesJson,
                        DateTime.UtcNow,
                        GetCurrentUserId()
                    );

                    historicos.Add(historico);
                }
            }

            if (historicos.Count != 0)
            {
                await HistoricoTarefas.AddRangeAsync(historicos);
            }
        }

        private static List<Modificacao> CapturarModificacoes(EntityEntry<Tarefa> entry)
        {
            var modificacoes = new List<Modificacao>();

            foreach (var prop in entry.Properties.Where(p => p.IsModified))
            {
                var valorAnterior = prop.OriginalValue?.ToString();
                var valorNovo = prop.CurrentValue?.ToString();

                if (valorAnterior != valorNovo)
                {
                    modificacoes.Add(new Modificacao(prop.Metadata.Name, valorAnterior, valorNovo));
                }
            }

            return modificacoes;
        }

        private int GetCurrentUserId()
        {
            // Lógica para obter o ID do usuário autenticado
            return 1; // Exemplo
        }



    }
}
