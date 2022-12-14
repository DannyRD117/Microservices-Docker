using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                ///Nos traemos el contexto actual
                var context = new ValidationContext<TRequest>(request);

                // ejecutamos todas las validaciones
                var validationResults = 
                    await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                // vamos a ver si hubo problemas de validacion
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                // tronamos los errores

                if (failures.Any())
                    throw new ValidationException(failures);

            }

            return await next();
        }
    }
}
