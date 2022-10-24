using AutoMapper;
using MediatR;
using Ordering.Application.Contracts;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class OrdersListQueryHandler : IRequestHandler<OrdersListQuery, List<OrdersViewModel>>
    {
        private readonly IGenericRepository<Order> orderRepository;
        private readonly IMapper mapper;

        public OrdersListQueryHandler(IGenericRepository<Order> orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task<List<OrdersViewModel>> Handle(OrdersListQuery request, CancellationToken cancellationToken)
        {
            // aqui va la logica de negocios
            var orders = await orderRepository.GetAsync(x => x.UserName == request.UserName);

            return mapper.Map<List<OrdersViewModel>>(orders);
        }
    }
}
