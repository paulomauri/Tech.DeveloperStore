using Ambev.Tech.DeveloperStore.Application.Products.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Products.Commands
{
    public record UpdateProductCommand(int Id, string Title, decimal Price, string Description, string Category, string Image, double Rate, int Count) : IRequest<ProductDto>;
}
