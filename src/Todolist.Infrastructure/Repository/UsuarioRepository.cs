using Microsoft.EntityFrameworkCore;
using Todolist.Domain.Aggregates;
using Todolist.Domain.Repositories;
using Todolist.Domain.Shared;
using Todolist.Infrastructure.Context;

namespace Todolist.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected readonly TodolistDbContext Db;
        protected readonly DbSet<Usuario> DbSet;

        public UsuarioRepository(TodolistDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Usuario>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Usuario?> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await DbSet.ToListAsync();
        }


        public void Add(Usuario usuario)
        {
            DbSet.Add(usuario);
        }

        public void Update(Usuario usuario)
        {
            DbSet.Update(usuario);
        }

        public void Remove(Usuario usuario)
        {
            DbSet.Remove(usuario);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
