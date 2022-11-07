using Basket.Api.Entities;
using Basket.Api.Repositories;
using Existance.Grpc.Protos;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController: ControllerBase
    {
        private readonly IBasketRepository basketRepository;
        private readonly ExistanceService.ExistanceServiceClient existanceService;

        public BasketController(IBasketRepository basketRepository, ExistanceService.ExistanceServiceClient existanceService)
        {
            this.basketRepository = basketRepository;
            this.existanceService = existanceService;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await basketRepository.GetBasket(userName);

            return Ok(basket ?? new ShoppingCart(userName));
        }
    }
}
