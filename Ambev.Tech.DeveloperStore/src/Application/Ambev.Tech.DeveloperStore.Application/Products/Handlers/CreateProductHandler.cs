using Ambev.Tech.DeveloperStore.Application.Interface;
using Ambev.Tech.DeveloperStore.Application.Products.Commands;
using Ambev.Tech.DeveloperStore.Application.Products.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Products.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product
            {
                Title = request.Title,
                Price = request.Price,
                Description = request.Description,
                Category = request.Category,

                ImageUrl = request.Image,
                Rating = request.Rate,

            };

            var createdProduct = await _productRepository.AddAsync(product);
            return new ProductDto
            {
                Id = createdProduct.Id,
                Title = createdProduct.Title,
                Price = createdProduct.Price,
                Description = createdProduct.Description,
                Category = createdProduct.Category,
                Image = createdProduct.Image,
                Rating = createdProduct.Rating,
            };
        }
    }
}
