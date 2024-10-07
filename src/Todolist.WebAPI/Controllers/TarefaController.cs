using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todolist.Application.UseCases.Commands.AtualizarTarefa;
using Todolist.Application.UseCases.Commands.CriarTarefa;
using Todolist.Application.UseCases.Commands.DeletarTarefa;
using Todolist.Application.UseCases.Queries.ObterDetalhesTarefa;

namespace Todolist.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TarefaController(IMediator mediator) : Controller
    {
        public readonly IMediator _mediator = mediator;


        [HttpGet("{tarefaId}")]
        public async Task<IActionResult> ObterDetalhesTarefa(int tarefaId)
        {
            var result = await _mediator.Send(new ObterDetalhesTarefaQuery { TarefaId = tarefaId });

            if (result.IsFailed)
                return BadRequest(result.Errors.Select(e => e.Message));

            return Ok(result.Value);
        }


        [HttpPost]
        public async Task<IActionResult> AdicionarTarefa([FromBody] CriarTarefaCommand command)
        {

            var result = await _mediator.Send(command);

            if (result.IsFailed)
                return BadRequest(result.Errors.Select(e => e.Message));

            return CreatedAtAction(nameof(AdicionarTarefa), new { id = result.Value });
        }


        [HttpPut]
        public async Task<IActionResult> AtualizarTarefa([FromBody] AtualizarTarefaCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailed)
                return BadRequest(result.Errors.Select(e => e.Message));

            return NoContent();
        }


        [HttpDelete("{tarefaId}")]
        public async Task<IActionResult> RemoverTarefa(int tarefaId)
        {
            var result = await _mediator.Send(new DeletarTarefaCommand { TarefaId = tarefaId });

            if (result.IsFailed)
                return BadRequest(result.Errors.Select(e => e.Message));

            return NoContent();
        }
    }
}
