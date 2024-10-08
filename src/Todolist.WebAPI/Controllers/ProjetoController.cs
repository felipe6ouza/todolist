using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todolist.Application.UseCases.Commands.CriarProjeto;
using Todolist.Application.UseCases.Commands.DeletarProjeto;
using Todolist.Application.UseCases.Queries.ListarTarefasProjeto;
using Todolist.Application.ViewModel;
using Todolist.WebAPI.Extensions;

namespace Todolist.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProjetoController(IMediator mediator) : Controller
    {
        public readonly IMediator _mediator = mediator;

        [HttpPost]
        [ProducesResponseType<int>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarProjeto([FromBody] CriarProjetoCommand command)
        {
            var result = await _mediator.Send(command);

            var errorResponse = result.VerificaErrosDeValidacao();

            if (errorResponse != null)
                return errorResponse;

            return CreatedAtAction(nameof(CriarProjeto), new { id = result.Value});
        }

        [HttpGet("{projetoId}/tarefas")]
        [ProducesResponseType<IEnumerable<ResumoTarefaViewModel>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterTarefasPorProjeto(int projetoId)
        {
            var result = await _mediator.Send(new ListarTarefasProjetoQuery { ProjetoId = projetoId});

            var errorResponse = result.VerificaErrosDeValidacao();

            if (errorResponse != null)
                return errorResponse;

            if (!result.Value.Any())
                return NotFound("Nenhuma tarefa encontrada para este projeto.");

            return Ok(result.Value);
        }

        [HttpDelete("{projetoId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletarProjeto(int projetoId)
        {
            var command = new DeletarProjetoCommand { ProjetoId = projetoId };
            var result = await _mediator.Send(command);

            var errorResponse = result.VerificaErrosDeValidacao();

            if (errorResponse != null)
                return errorResponse;

            return NoContent(); 
        }

    }
}
