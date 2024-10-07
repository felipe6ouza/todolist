namespace Todolist.Domain.View
{
    public class RelatorioTarefasConcluidasView
    {
        public int ResponsavelId { get; set; }
        public string ResponsavelNome { get; set; }
        public int TotalTarefasConcluidas { get; set; }
        public int MediaDiasConclusao { get; set; }
    }
}
