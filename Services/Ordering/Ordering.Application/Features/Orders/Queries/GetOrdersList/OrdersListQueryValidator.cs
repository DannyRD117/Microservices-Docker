using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class OrdersListQueryValidator : AbstractValidator<OrdersListQuery>
    {
        public OrdersListQueryValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("El UserName no puede ser vacio")
                .MinimumLength(3)
                .WithMessage("El UserName debe ser mayor a 3 caracteres")
                .MaximumLength(10);
        }
    }
}
