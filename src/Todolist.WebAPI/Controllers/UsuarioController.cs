﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todolist.Application.UseCases.Queries.ListarProjetosUsuario;
using Todolist.Application.UseCases.Queries.ListarUsuarios;
using Todolist.Application.UseCases.Queries.ObterRelatorioDesempenho;
using Todolist.Application.ViewModel;
using Todolist.Domain.View;

namespace Todolist.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController(IMediator mediator) : Controller
    {
        public readonly IMediator _mediator = mediator;

        [HttpGet("todos")]
        [ProducesResponseType<IEnumerable<UsuarioViewModel>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterUsuarios()
        {
            var relatorioUsuarios = await _mediator.Send(new ListarUsuariosQuery());

            if (relatorioUsuarios.IsFailed)
                return NotFound("Nenhum usuário disponível");

            return Ok(relatorioUsuarios.Value);
        }



        [HttpGet("{usuarioId}/projetos")]
        [ProducesResponseType<IEnumerable<ProjetoViewModel>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType<IEnumerable<RelatorioTarefasConcluidasView>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
