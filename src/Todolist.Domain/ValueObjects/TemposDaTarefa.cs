namespace Todolist.Domain.ValueObjects
{
    public class TemposDaTarefa
    {
        protected TemposDaTarefa() { }
        public TemposDaTarefa (DateTime? dataInicial, DateTime? prazo)
        {
            DataInicial = dataInicial;
            Prazo = prazo;
        }

        public DateTime? DataInicial { get; private set; } 
        public DateTime? Prazo { get; private set; }
    }


}
