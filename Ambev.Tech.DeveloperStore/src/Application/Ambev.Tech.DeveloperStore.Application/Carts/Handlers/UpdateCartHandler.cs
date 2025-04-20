using Ambev.Tech.DeveloperStore.Application.Carts.Commands;
using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using Ambev.Tech.DeveloperStore.Application.Interface;
using Ambev.Tech.DeveloperStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Carts.Handlers
{

    public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, CartDto>
    {
        private readonly ICartRepository _cartRepository;

        public UpdateCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartDto> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(request.Id);

            if (cart == null)
                throw new Exception("Cart not found");

            cart.Items = request.CartDto.Products.Select(p => new CartItem
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList();

            var cartUpdated = await _cartRepository.UpdateAsync(cart);
            return cartUpdated;
        }
    }
}
