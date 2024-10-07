using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todolist.Application.UseCases.Queries.ListarProjetosUsuario;
using Todolist.Application.UseCases.Queries.ObterRelatorioDesempenho;

namespace Todolist.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController(IMediator mediator) : Controller
    {
        public readonly IMediator _mediator = mediator;

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


        [HttpGet("{usuarioId}/relatorio-desempenho")]
        public async Task<IActionResult> ObterRelatorioDesempenho(int usuarioId)
        {
            var relatorioDesempenho = await _mediator.Send(new ObterRelatorioDesempenhoQuery { UsuarioId = usuarioId });

            if(relatorioDesempenho.IsFailed)
                return Forbid();

            if (relatorioDesempenho.Value == null || !relatorioDesempenho.Value.Any())
                return NotFound("Nenhum relatório disponível");

            return Ok(relatorioDesempenho.Value);
        }
    }
}
