using Microsoft.EntityFrameworkCore;
using Todolist.Domain.Aggregates;
using Todolist.Domain.Repositories;
using Todolist.Domain.Shared;
using Todolist.Infrastructure.Data.Context;

namespace Todolist.Infrastructure.Data.Repository
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

        public async Task<Projeto?> ObterPorId(int id)
        {
            return await DbSet
                .Include(c => c.Tarefas)
                .Include(c => c.Autor)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public void Criar(Projeto projeto)
        {
            DbSet.Add(projeto);
        }

        public void Atualizar(Projeto projeto)
        {
            DbSet.Update(projeto);
        }

        public void Remover(Projeto projeto)
        {
            DbSet.Remove(projeto);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this); 

        }

        public async Task<IEnumerable<Projeto>> BuscarProjetosUsuario(int id)
        {
            return await DbSet.Include(c => c.Tarefas).Include(c => c.Autor).Where(c => c.Autor!.Id == id).ToListAsync();
        }
    }
}
