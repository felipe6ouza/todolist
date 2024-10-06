using Microsoft.EntityFrameworkCore;
using Todolist.Domain.Aggregates;
using Todolist.Domain.Repositories;
using Todolist.Domain.Shared;
using Todolist.Infrastructure.Context;

namespace Todolist.Infrastructure.Repository
{
    public class ProjetoRepository : IProjetoRepository
    {
        protected readonly TodolistDbContext Db;
        protected readonly DbSet<Projeto> DbSet;

        public ProjetoRepository(TodolistDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Projeto>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Projeto?> GetById(int id)
        {
            return await DbSet
                .Include(c => c.Tarefas)
                .Include(c => c.Autor)  
                .FirstOrDefaultAsync(c => c.Id == id); 
        }

        public async Task<IEnumerable<Projeto>> GetAll()
        {
            return await DbSet.ToListAsync();
        }


        public void Add(Projeto projeto)
        {
            DbSet.Add(projeto);
        }

        public void Update(Projeto projeto)
        {
            DbSet.Update(projeto);
        }

        public void Remove(Projeto projeto)
        {
            DbSet.Remove(projeto);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<Projeto>> BuscarProjetosUsuario(int id)
        {
            return await DbSet.Include(c => c.Tarefas).Include(c=> c.Autor).Where(c => c.Autor.Id == id).ToListAsync();
        }
    }
}
