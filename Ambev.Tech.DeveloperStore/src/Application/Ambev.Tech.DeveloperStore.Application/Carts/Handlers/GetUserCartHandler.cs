using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using Ambev.Tech.DeveloperStore.Application.Carts.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Carts.Handlers
{
    public class GetUserCartHandler : IRequestHandler<GetUserCartQuery, CartDto>
    {
        private readonly ICartRepository _cartRepository;

        public GetUserCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartDto> Handle(GetUserCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetUserCartAsync(request.UserId);
            return cart == null ? null : new CartDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Date = cart.Date,
                Products = cart.Products
            };
        }
    }
}
