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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        // GET api/product
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }

        // GET api/product/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/product
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var createdProduct = await _productRepository.AddAsync(product);
            var createdProductDto = _mapper.Map<ProductDto>(createdProduct);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProductDto.Id }, createdProductDto);
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.Id = id;

            var updatedProduct = await _productRepository.UpdateAsync(product);
            if (updatedProduct == null)
                return NotFound();

            var updatedProductDto = _mapper.Map<ProductDto>(updatedProduct);
            return Ok(updatedProductDto);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
