using Microsoft.EntityFrameworkCore;
using Todolist.Domain.Aggregates;
using Todolist.Domain.Repositories;
using Todolist.Domain.Shared;
using Todolist.Infrastructure.Data.Context;

namespace Todolist.Infrastructure.Data.Repository
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


        public async Task<Usuario?> ObterPorId(int id)
        {
            return await DbSet.Include(c => c.FuncaoUsuario).FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Criar(Usuario usuario)
        {
            DbSet.Add(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            DbSet.Update(usuario);
        }

        public void Remover(Usuario usuario)
        {
            DbSet.Remove(usuario);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
