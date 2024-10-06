using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todolist.Application.UseCases.Commands.CriarProjeto;
using Todolist.Application.UseCases.Queries.ListarTarefasProjeto;

namespace Todolist.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProjetoController(IMediator mediator) : Controller
    {
        public readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CriarProjeto([FromBody] CriarProjetoCommand command)
        {
            var result = await _mediator.Send(command); 

            if (result.IsFailed) 
                return BadRequest(result.Errors.Select(e => e.Message)); 

            return CreatedAtAction(nameof(CriarProjeto), new { id = result.Value});
        }

        [HttpGet("{projetoId}/tarefas")]
        public async Task<IActionResult> ObterTarefasPorProjeto(int projetoId)
        {
            var result = await _mediator.Send(new ListarTarefasProjetoQuery { ProjetoId = projetoId});

            if (result.IsFailed)
                return BadRequest(result.Errors.Select(e => e.Message));

            if(!result.Value.Any())
                return NotFound("Nenhuma tarefa encontrada para este projeto.");

            return Ok(result.Value);
        }
    }
}
