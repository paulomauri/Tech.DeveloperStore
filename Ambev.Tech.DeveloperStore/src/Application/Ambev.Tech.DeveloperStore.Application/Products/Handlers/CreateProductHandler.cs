using Ambev.Tech.DeveloperStore.Application.Interface;
using Ambev.Tech.DeveloperStore.Application.Products.Commands;
using Ambev.Tech.DeveloperStore.Application.Products.Dto;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.Tech.DeveloperStore.Application.Products.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CreateProductHandler> _logger;

        public CreateProductHandler(IProductRepository productRepository, ILogger<CreateProductHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando criação do produto {Title}", request.Title);

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
            
            _logger.LogInformation("Produto com ID {Id} atualizado com sucesso", createdProduct.Id);

            return new ProductDto
            {
                Id = createdProduct.Id,
                Title = createdProduct.Title,
                Price = createdProduct.Price,
                Description = createdProduct.Description,
                Category = createdProduct.Category,
                Image = createdProduct.ImageUrl,
                Rating = createdProduct.Rating,
            };
        }
    }
}
