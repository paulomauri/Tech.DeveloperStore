using MediatR;
using Ambev.Tech.DeveloperStore.Application.Products.Dto;

namespace Ambev.Tech.DeveloperStore.Application.Products.Queries
{
    public record GetAllProductsQuery(int Page = 1, int Size = 10, string? Order = null) : IRequest<List<ProductDto>>;
}
