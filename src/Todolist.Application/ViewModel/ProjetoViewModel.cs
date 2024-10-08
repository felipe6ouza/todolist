namespace Todolist.Application.ViewModel
{
    public class ProjetoViewModel
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public bool Favorito { get; set; }
        public bool Ativo { get; set; }
    }

}
