namespace Todolist.Application.ViewModel
{
    public class ResumoTarefaViewModel
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public int PrioridadeId { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFinal { get; set; }
        public int StatusTarefaId { get; set; }
        public int QuantidadeComentarios { get; set; }

    }

}
