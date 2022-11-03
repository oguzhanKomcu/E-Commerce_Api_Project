using ECommerceApi.Application.CQRS.Address.Commands.Request;
using ECommerceApi.Application.CQRS.Address.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController
    {


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAddressCommandRequest createCategoryCommand)
        {
            var result = await Mediator.Send(createCategoryCommand);
            return Created("", result);
        }




        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteAddressCommandRequest deleteCategoryCommand)
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

       

        [HttpGet("UserAddress")]
        public async Task<IActionResult> UserAddress(GetUserAddressListQueryRequest userId)
        {

            var result = await Mediator.Send(userId);
            return Ok(result);
        }
    }
}
