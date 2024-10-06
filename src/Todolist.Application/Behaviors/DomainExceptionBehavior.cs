using FluentResults;
using MediatR;
using Todolist.Domain.Shared;

namespace Todolist.Application.Behaviors
{
    public class DomainExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommandBase
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (DomainException ex)
            {
                if (typeof(TResponse) == typeof(Result<int>))
                {
                    return (TResponse)(object)Result.Fail<int>(ex.Message);
                }

                return (TResponse)(object)Result.Fail(ex.Message);
            }
        }
    }



}
