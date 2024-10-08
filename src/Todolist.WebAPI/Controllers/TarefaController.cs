﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todolist.Application.UseCases.Commands.AdicionarComentarioTarefa;
using Todolist.Application.UseCases.Commands.AtualizarTarefa;
using Todolist.Application.UseCases.Commands.CriarTarefa;
using Todolist.Application.UseCases.Commands.DeletarTarefa;
using Todolist.Application.UseCases.Queries.ObterDetalhesTarefa;
using Todolist.Application.ViewModel;
using Todolist.WebAPI.Extensions;

namespace Todolist.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TarefaController(IMediator mediator) : Controller
    {
        public readonly IMediator _mediator = mediator;


        [HttpGet("{tarefaId}")]
        [ProducesResponseType<DetalhesTarefaViewModel>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterDetalhesTarefa(int tarefaId)
        {
            var result = await _mediator.Send(new ObterDetalhesTarefaQuery { TarefaId = tarefaId });

            var errorResponse = result.VerificaErrosDeValidacao();
            if (errorResponse != null)
                return errorResponse;

            return Ok(result.Value);
        }


        [HttpPost]
        [ProducesResponseType<int>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarTarefa([FromBody] CriarTarefaCommand command)
        {

            var result = await _mediator.Send(command);

            var errorResponse = result.VerificaErrosDeValidacao();
            
            if (errorResponse != null)
                return errorResponse;
  
            return CreatedAtAction(nameof(AdicionarTarefa), new { id = result.Value });
        }


        [HttpPost("{tarefaId}/comentario")]
        [ProducesResponseType<int>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarComentarioTarefa(int tarefaId, [FromBody] AdicionarComentarioTarefaCommand command)
        {
            command.TarefaId = tarefaId;

            var result = await _mediator.Send(command);

            var errorResponse = result.VerificaErrosDeValidacao();

            if (errorResponse != null)
                return errorResponse;

            return CreatedAtAction(nameof(AdicionarTarefa), new { id = result.Value });
        }



        [HttpPut("{tarefaId}")]
        [ProducesResponseType<int>(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarTarefa(int tarefaId, [FromBody] AtualizarTarefaCommand command)
        {
            command.TarefaId = tarefaId;

            var result = await _mediator.Send(command);

            var errorResponse = result.VerificaErrosDeValidacao();

            if (errorResponse != null)
                return errorResponse;

            return NoContent();
        }


        [HttpDelete("{tarefaId}")]
        [ProducesResponseType<int>(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoverTarefa(int tarefaId)
        {
            var result = await _mediator.Send(new DeletarTarefaCommand { TarefaId = tarefaId });

            var errorResponse = result.VerificaErrosDeValidacao();

            if (errorResponse != null)
                return errorResponse;

            return NoContent();
        }
    }
}
