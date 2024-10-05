namespace Todolist.Domain.ValueObjects
{
    public class TemposDaTarefa(DateTime dataInicial, DateTime? prazo)
    {
        public DateTime DataInicial { get; private set; } = dataInicial;
        public DateTime? Prazo { get; private set; } = prazo;
    }


}
