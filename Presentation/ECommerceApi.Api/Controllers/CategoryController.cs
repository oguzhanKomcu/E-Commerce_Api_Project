using ECommerceApi.Application.CQRS.Category.Commands.Request;
using ECommerceApi.Application.CQRS.Category.Commands.Response;
using ECommerceApi.Application.CQRS.Category.Queries.Request;
using ECommerceApi.Application.CQRS.Category.Queries.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommandRequest createCategoryCommand)
        {
            CreateCategoryCommandResponse result = await Mediator.Send(createCategoryCommand);
            return Created("", result);
        }




        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommandRequest deleteCategoryCommand)
        {
            DeleteCategoryCommandResponse result = await Mediator.Send(deleteCategoryCommand);

            if (result.IsSuccess == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }
        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <param name="GetCategoriesQuery"></param>
        /// <returns></returns>
        [HttpGet("AllCategory")]
        public async Task<IActionResult> AllCategory(GetCategoriesQueryRequest GetCategoriesQuery)
        {

            var result = await Mediator.Send(GetCategoriesQuery);
            return Ok(result);
        }

    }
}
