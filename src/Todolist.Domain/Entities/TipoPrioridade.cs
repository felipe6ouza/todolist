
using Todolist.Domain.ValueObjects;

namespace Todolist.Domain.Entities
{
    public class TipoPrioridade(string descricacao, CorHexadecimal cor)
    {
        public int PrioridadeId { get; private set; }
        public string Descricao { get; private set; } = descricacao;
        public CorHexadecimal Cor { get; private set; } = cor;
    }


}
