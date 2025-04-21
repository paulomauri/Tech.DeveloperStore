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
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            product.Title = request.Title;
            product.Price = request.Price;
            product.Description = request.Description;
            product.Category = request.Category;
            product.ImageUrl = request.Image;
            product.Rating = request.Rate;

            var updatedProduct = await _productRepository.UpdateAsync(product);

            return new ProductDto
            {
                Id = updatedProduct.Id,
                Title = updatedProduct.Title,
                Price = updatedProduct.Price,
                Description = updatedProduct.Description,
                Category = updatedProduct.Category,
                Image = updatedProduct.ImageUrl,
                Rating = updatedProduct.Rating
            };
        }
    }
}

