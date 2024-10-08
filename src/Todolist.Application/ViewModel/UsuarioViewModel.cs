namespace Todolist.Application.ViewModel
{
    public class UsuarioViewModel
    {
        public int? Id { get; set; }  
        public required string Nome { get; set; }  
        public int? FuncaoUsuarioId {  get; set; }
        public required string DescricaoFuncaoUsuario { get; set; }


    }

}
