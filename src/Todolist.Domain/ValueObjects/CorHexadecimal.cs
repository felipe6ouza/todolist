using System.Text.RegularExpressions;
using Todolist.Domain.Shared;

namespace Todolist.Domain.ValueObjects
{
    public class CorHexadecimal
    {
        public string Valor { get; private set; }

        public CorHexadecimal(string valor)
        {
            if (!ValidaCor(valor))
            {
                throw new DomainException("Código hexadecimal para cor inválido");
            }

            Valor = valor;
        }

        private static bool ValidaCor(string valor)
        {
            return Regex.IsMatch(valor, "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
        }
    }


}
