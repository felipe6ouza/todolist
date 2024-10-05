﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Projeto?> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
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
    }
}
