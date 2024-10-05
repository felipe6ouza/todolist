namespace Todolist.Domain.ValueObjects
{
    public class StatusProjeto(bool marcadoComoFavorito, bool ativo)
    {
        public bool Favorito { get; private set; } = marcadoComoFavorito;
        public bool Ativo { get; private set; } = ativo;
    }


}
