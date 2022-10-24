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
                .MaximumLength(10);
        }
    }
}
