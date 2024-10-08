using Microsoft.EntityFrameworkCore;
using Todolist.Domain.Repositories;
using Todolist.Domain.View;
using Todolist.Infrastructure.Data.Context;

namespace Todolist.Infrastructure.Data.Repository
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
