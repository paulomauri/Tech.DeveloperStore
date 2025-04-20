using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using Ambev.Tech.DeveloperStore.Application.Carts.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Carts.Queries;
using Domain.Interfaces;

namespace Ambev.Tech.DeveloperStore.Application.Carts.Handlers
{
    public class GetAllCartsHandler : IRequestHandler<GetAllCartsQuery, List<CartDto>>
    {
        private readonly ICartRepository _cartRepository;

        public GetAllCartsHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<List<CartDto>> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
        {
            var carts = await _cartRepository.GetAllCartsAsync();
            return carts.ConvertAll(cart => new CartDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Date = cart.Date,
                Products = cart.Products
            });
        }
    }
}
