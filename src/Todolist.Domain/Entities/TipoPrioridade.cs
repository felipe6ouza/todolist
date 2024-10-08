namespace Todolist.Domain.Entities
{
    public class TipoPrioridade
    {
        public int? PrioridadeId { get; private set; }
        public string? Descricao { get; private set; }

        protected TipoPrioridade() { }
        public TipoPrioridade(string descricacao)
        {   
            Descricao = descricacao;
        }
    }


}
