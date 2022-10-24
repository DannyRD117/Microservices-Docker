
using MediatR;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class OrdersListQuery : IRequest<List<OrdersViewModel>>
    {
        public string UserName { get; set; }

        public OrdersListQuery(string userName)
        {
            UserName = userName;
        }
    }
}
