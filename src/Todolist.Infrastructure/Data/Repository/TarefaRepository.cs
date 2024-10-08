using Microsoft.EntityFrameworkCore;
using Todolist.Domain.Aggregates;
using Todolist.Domain.Entities;
using Todolist.Domain.Repositories;
using Todolist.Domain.Shared;
using Todolist.Infrastructure.Data.Context;


namespace Todolist.Infrastructure.Data.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        protected readonly TodolistDbContext Db;
        protected readonly DbSet<Tarefa> DbSet;

        public TarefaRepository(TodolistDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Tarefa>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Tarefa?> ObterPorId(int id)
        {
            return await DbSet.Include(c => c.Autor)
                .Include(c => c.Responsavel)
                .Include(c => c.Comentarios)
                .Include(c => c.Projeto).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefasPorProjetoId(int projetoId)
        {
            return await DbSet
                .Where(t => t.ProjetoId == projetoId)
                .ToListAsync();
        }

        public void Criar(Tarefa tarefa)
        {
            DbSet.Add(tarefa);
        }

        public void Atualizar(Tarefa tarefa)
        {
            DbSet.Update(tarefa);
        }

        public void Remover(Tarefa tarefa)
        {
            DbSet.Remove(tarefa);
        }

        public async Task AdicionarHistoricoTarefa(HistoricoTarefa historicoTarefa)
        {
            await Db.HistoricoTarefas.AddAsync(historicoTarefa);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this); 

        }


    }
}
