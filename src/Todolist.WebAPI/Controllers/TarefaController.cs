using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todolist.Application.UseCases.Commands.AtualizarTarefa;
using Todolist.Application.UseCases.Commands.CriarTarefa;

namespace Todolist.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TarefaController : Controller
    {
        public readonly IMediator _mediator;

        public TarefaController(IMediator mediator)
        {
            _mediator = mediator;
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
                return BadRequest(result.Errors);

            return NoContent(); 
        }
    }
}
