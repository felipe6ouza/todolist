using Microsoft.EntityFrameworkCore;
using Todolist.Domain.Repositories;
using Todolist.Domain.View;
using Todolist.Infrastructure.Context;

namespace Todolist.Infrastructure.Repository
{
    public class RelatorioDesempenhoRepository(TodolistDbContext context) : IRelatorioDesempenhoRepository
    {
        protected readonly TodolistDbContext Db = context;

        public async Task<IEnumerable<RelatorioTarefasConcluidasView>> ObterRelatorioDesempenho()
        {
            return await Db.RelatorioTarefasConcluidas.ToListAsync();
        }
    }

}
