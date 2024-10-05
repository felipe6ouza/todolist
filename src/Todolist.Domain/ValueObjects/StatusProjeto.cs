namespace Todolist.Domain.ValueObjects
{
    public class StatusProjeto
    {
        protected StatusProjeto() { }

        public StatusProjeto(bool marcadoComoFavorito, bool ativo)
        {
            Favorito = marcadoComoFavorito;
            Ativo = ativo;
        }
        public bool Favorito { get; private set; } 
        public bool Ativo { get; private set; }
    }


}
