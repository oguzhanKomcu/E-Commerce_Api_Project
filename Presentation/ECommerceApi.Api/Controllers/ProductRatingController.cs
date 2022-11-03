using ECommerceApi.Application.CQRS.Product_Rating.Commands.Request;

using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ProductRatingController : BaseController
    {
        


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRatingCommandRequest createproductRatingCommand)
        {
            var result = await Mediator.Send(createproductRatingCommand);
            return Created("", result);
        }





    }
}