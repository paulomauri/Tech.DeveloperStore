using Ambev.Tech.DeveloperStore.Application.Carts.Commands;
using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using Ambev.Tech.DeveloperStore.Application.Carts.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.Tech.DeveloperStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/cart
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CartDto>>> GetAllCarts()
        {
            var result = await _mediator.Send(new GetAllCartsQuery());
            return Ok(result);
        }

        // GET api/cart/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CartDto>> GetCartById(int id)
        {
            var result = await _mediator.Send(new GetCartByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/cart
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CartDto>> CreateCart([FromBody] CreateCartCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCartById), new { id = result.Id }, result);
        }

        // PUT api/cart/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateCart(int id, [FromBody] UpdateCartCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id do corpo e da URL não coincidem.");

            var result = await _mediator.Send(command);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // DELETE api/cart/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var result = await _mediator.Send(new DeleteCartCommand { Id = id });
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
