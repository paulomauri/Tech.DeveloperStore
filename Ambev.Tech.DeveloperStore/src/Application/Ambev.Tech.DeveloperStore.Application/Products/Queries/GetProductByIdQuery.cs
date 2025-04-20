using MediatR;
using Ambev.Tech.DeveloperStore.Application.Products.Dto;

namespace Ambev.Tech.DeveloperStore.Application.Products.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
}