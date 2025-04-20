using Ambev.Tech.DeveloperStore.Application.Carts.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Carts.Commands;
using MediatR;
using Domain.Entities;
using Domain.Interfaces;

namespace Ambev.Tech.DeveloperStore.Application.Carts.Handlers
{
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, int>
    {
        private readonly ICartRepository _cartRepository;

        public CreateCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<int> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = new Cart
            {
                UserId = request.UserId,
                Date = request.Date,
                Products = request.Products.Select(p => new CartItem
                {
                    ProductId = p.ProductId,
                    Quantity = p.Quantity
                }).ToList()
            };

            var createdCart = await _cartRepository.AddAsync(cart);
            return createdCart.Id;
        }
    }
}
