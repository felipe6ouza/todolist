using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todolist.Application.UseCases.Queries.ListarProjetosUsuario;

namespace Todolist.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        public readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{usuarioId}/projetos")]
        public async Task<IActionResult> ListarProjetosUsuario(int usuarioId)
        {
            var projetos = await _mediator.Send(new ListarProjetosUsuarioQuery { UsuarioId = usuarioId});
            
            if (projetos == null || !projetos.Any())
            {
                return NotFound("Nenhum projeto encontrado para o usuário.");
            }
            return Ok(projetos);
        }



    }
}
