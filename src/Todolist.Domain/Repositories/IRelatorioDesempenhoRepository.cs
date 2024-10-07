using Todolist.Domain.View;

namespace Todolist.Domain.Repositories
{
    public interface IRelatorioDesempenhoRepository 
    {
        Task<IEnumerable<RelatorioTarefasConcluidasView>> ObterRelatorioDesempenho();   
    }
}
