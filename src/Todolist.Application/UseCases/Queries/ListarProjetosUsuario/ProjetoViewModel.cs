namespace Todolist.Application.UseCases.Queries.ListarProjetosUsuario
{
    public class ProjetoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Favorito { get; set; }
        public bool Ativo { get; set; }
    }

}
