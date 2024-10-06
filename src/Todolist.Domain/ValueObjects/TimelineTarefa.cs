namespace Todolist.Domain.ValueObjects
{
    public class TimelineTarefa
    {
        protected TimelineTarefa() { }
        public TimelineTarefa (DateTime? dataFinal)
        {
            DataInicial = DateTime.Now;
            DataFinal = dataFinal;
        }

        public DateTime? DataInicial { get; private set; } 
        public DateTime? DataFinal { get; private set; }

        public void AtualizarDataFinal (DateTime dataFinal)
        {
            DataFinal = dataFinal;
        }
    }


}
