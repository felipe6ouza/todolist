namespace Todolist.Domain.ValueObjects
{
    public class Modificacao(string propriedade, string? valorAnterior, string? valorNovo)
    {
        public string Propriedade { get; private set; } = propriedade;
        public string? ValorAnterior { get; private set; } = valorAnterior;
        public string? ValorNovo { get; private set; } = valorNovo;
    }

}
