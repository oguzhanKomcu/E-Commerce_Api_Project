
using ECommerceApi.Application.CQRS.Product_Comment.Commands.Request;
using ECommerceApi.Application.CQRS.Product_Comment.Commands.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCommentController : BaseController
    {



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommentCommandRequest createproductCommentCommand)
        {
            var result = await Mediator.Send(createproductCommentCommand);
            return Created("", result);
        }




        [HttpDelete] 
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommentCommandRequest deleteproductCommentCommand)
        {
            var result = await Mediator.Send(deleteproductCommentCommand);

            if (result.IsSuccess == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommentCommandRequest model)
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