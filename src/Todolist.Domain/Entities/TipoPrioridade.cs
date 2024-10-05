namespace Todolist.Domain.Entities
{
    public class TipoPrioridade
    {
        protected TipoPrioridade() { }

        public TipoPrioridade(string descricacao)
        {   
            Descricao = descricacao;
        }

        public int? PrioridadeId { get; private set; }
        public string? Descricao { get; private set; }
    }


}
