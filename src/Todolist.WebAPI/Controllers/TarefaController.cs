using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todolist.Application.UseCases.Commands.CriarProjeto;

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
        //[HttpPost]
        //public async Task<IActionResult> CriarTarefa([FromBody] CriarProjetoCommand command)
        //{
            
        //    var result = await _mediator.Send(command); 

        //    if (result.IsFailed) 
        //        return BadRequest(result.Errors.Select(e => e.Message)); 


        //    return CreatedAtAction(nameof(CriarProjeto), new { id = result.Value});
        //}





    }
}
