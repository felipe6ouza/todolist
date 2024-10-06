namespace Todolist.Domain.Entities
{
    public class StatusTarefa
    {
        public int? Id { get; set; }
        public string? Descricao { get; set; }

        protected StatusTarefa() { }

        public StatusTarefa(int id)
        {
            Id = id;
        }
    }

}

