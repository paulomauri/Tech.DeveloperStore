using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using Ambev.Tech.DeveloperStore.Application.Interface;
using Ambev.Tech.DeveloperStore.Application.Products.Dto;
using Ambev.Tech.DeveloperStore.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.Tech.DeveloperStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartController(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;   
        }

        // GET api/cart
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CartDto>>> GetAllCarts()
        {
            var carts = await _cartRepository.GetAllAsync();
            var cartsDtos = _mapper.Map<IEnumerable<CartDto>>(carts);
            return Ok(cartsDtos);
        }

        // GET api/cart/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CartDto>> GetCartById(int id)
        {
            var cart = await _cartRepository.GetByIdAsync(id);
            var cartDto = _mapper.Map<IEnumerable<CartDto>>(cart);

            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cartDto);
        }

        // POST api/cart
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CartDto>> CreateCart([FromBody] CartDto cartDto)
        {
            var cart = _mapper.Map<Cart>(cartDto);
            var createdCart = await _cartRepository.AddAsync(cart);
            var createdCartDto = _mapper.Map<CartDto>(createdCart);

            return CreatedAtAction(nameof(GetCartById), new { id = cart.Id }, cart);
        }

        // PUT api/cart/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateCart(int id, [FromBody] CartDto cartDto)
        {
            var cart = _mapper.Map<Cart>(cartDto);
            cartDto.Id = id;

            var existingCart = await _cartRepository.GetByIdAsync(id);
            if (existingCart == null)
            {
                return NotFound();
            }

            var updatedCart = await _cartRepository.UpdateAsync(cart);
            if (updatedCart == null)
                return NotFound();

            var updatedCartDto = _mapper.Map<ProductDto>(updatedCart);
            return Ok(updatedCartDto);
        }

        // DELETE api/cart/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _cartRepository.GetByIdAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            await _cartRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
