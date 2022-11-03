
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using ECommerceApi.Application.CQRS.Order.Commands.Request;
using ECommerceApi.Application.CQRS.Order.Queries.Request;
using ECommerceApi.Application.CQRS.Product.Commands.Request;
using ECommerceApi.Application.CQRS.Product.Model;
using ECommerceApi.Application.CQRS.Product.Queries.Request;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommandRequest createOrderCommand)
        {
            var result = await Mediator.Send(createOrderCommand);
            return Created("", result);
        }



        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOrderCommandRequest deleteOrderCommand)
        {
            var result = await Mediator.Send(deleteOrderCommand);

            if (result.IsSuccess == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders([FromQuery] PageRequest pageRequest)
        {

            var getListModelQuery = new GetOrderListQueryRequest { PageRequest = pageRequest };
            var result = await Mediator.Send(getListModelQuery);
            return Ok(result);

        }

        


        [HttpGet("GetByDynamicorders")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            var getListModelByDynamicQuery = new GetListOrderByDynamicQueryRequest { PageRequest = pageRequest, Dynamic = dynamic };
            var result = await Mediator.Send(getListModelByDynamicQuery);
            return Ok(result);
        }

    }
}
