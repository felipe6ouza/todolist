using FluentValidation;
using MediatR;
using Todolist.Domain.Shared;

namespace Todolist.Application.Behaviors
{
    public sealed class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
     : IPipelineBehavior<TRequest, TResponse>
     where TRequest : ICommandBase
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationFailures = await Task.WhenAll(_validators.Select(validator => validator.ValidateAsync(context)));

            var errors = validationFailures
                .Where(validationResult => !validationResult.IsValid)
                .SelectMany(validationResult => validationResult.Errors)
                .ToList();

            if (errors.Count != 0)
            {
                throw new ValidationException(errors);
            }

            var response = await next();

            return response;
        }
    }
}
