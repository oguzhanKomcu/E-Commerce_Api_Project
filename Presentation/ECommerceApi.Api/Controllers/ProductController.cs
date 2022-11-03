using Core.Application.Requests;
using Core.Persistence.Dynamic;
using ECommerceApi.Application.CQRS.Product.Commands.Request;
using ECommerceApi.Application.CQRS.Product.Commands.Response;
using ECommerceApi.Application.CQRS.Product.Handlers.Commands;
using ECommerceApi.Application.CQRS.Product.Model;
using ECommerceApi.Application.CQRS.Product.Queries.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommandRequest createProductCommand)
        {
            CreateProductCommandResponse result = await Mediator.Send(createProductCommand);
            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] CreateProductCommandRequest deleteCategoryCommand)
        {
            var result = await Mediator.Send(deleteCategoryCommand);

            if (result.IsSuccess == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet("ProductDetails")]
        public async Task<IActionResult> ProductDetails(GetProductByCategoryQueryRequest productId)
        {
            var  result = await Mediator.Send(productId);

            return Ok(result);
        }

        [HttpGet("ProductsByCategory")]
        public async Task<IActionResult> ProductsByCategory(GetProductByCategoryQueryRequest category)
        {
            var result = await Mediator.Send(category);

            return Ok(result);
        }


        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts([FromQuery] PageRequest pageRequest)
        {

            GetAllProductQueryRequest getListModelQuery = new GetAllProductQueryRequest { PageRequest = pageRequest };
            ProductListModel result = await Mediator.Send(getListModelQuery);
            return Ok(result);
            
        }

        [HttpGet("GetByDynamicProducts")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListProductByDynamicQueryRequest getListModelByDynamicQuery = new GetListProductByDynamicQueryRequest { PageRequest = pageRequest, Dynamic = dynamic };
            ProductListModel result = await Mediator.Send(getListModelByDynamicQuery);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandRequest model)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(model);

                return Ok();


            }
            else
            {
                
                ModelState.AddModelError(String.Empty, "Product hasn't been added..!!");
                return BadRequest(ModelState);
            }

        }
    }
}
