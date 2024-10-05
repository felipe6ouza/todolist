using Microsoft.EntityFrameworkCore;
using Todolist.Domain.Aggregates;
using Todolist.Domain.Repositories;
using Todolist.Domain.Shared;
using Todolist.Infrastructure.Context;


namespace Todolist.Infrastructure.Repository
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

        public async Task<Tarefa?> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Tarefa>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public void Add(Tarefa tarefa)
        {
            DbSet.Add(tarefa);
        }

        public void Update(Tarefa tarefa)
        {
            DbSet.Update(tarefa);
        }

        public void Remove(Tarefa tarefa)
        {
            DbSet.Remove(tarefa);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

       
    }
}
