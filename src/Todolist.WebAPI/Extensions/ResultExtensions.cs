using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Todolist.WebAPI.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult? VerificaErrosDeValidacao<T>(this IResult<T> result)
        {
            if (result.IsFailed)
            {
                var erros = result.Errors.Select(e => new
                {
                    errorMessage = e.Message
                });

                return new BadRequestObjectResult(new { Erros = erros });
            }

            return null;
        }

        public static IActionResult? VerificaErrosDeValidacao(this Result result)
        {
            if (result.IsFailed)
            {
                var erros = result.Errors.Select(e => new
                {
                    errorMessage = e.Message
                });

                return new BadRequestObjectResult(new { Erros = erros });
            }

            return null;
        }
    }

}
