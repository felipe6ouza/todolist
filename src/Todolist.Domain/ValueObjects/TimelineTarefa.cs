namespace Todolist.Domain.ValueObjects
{
    public class TimelineTarefa
    {
        protected TimelineTarefa() { }
        public TimelineTarefa (DateTime? dataInicial, DateTime? dataFinal)
        {
            DataInicial = dataInicial;
            DataFinal = dataFinal;
        }

        public DateTime? DataInicial { get; private set; } 
        public DateTime? DataFinal { get; private set; }
    }


}
