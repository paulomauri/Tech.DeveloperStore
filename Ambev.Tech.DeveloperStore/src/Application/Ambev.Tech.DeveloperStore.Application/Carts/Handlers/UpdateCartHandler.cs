using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Carts.Handlers
{
    using Application.Carts.Commands;
    using MediatR;
    using Domain.Entities;
    using Domain.Interfaces;
    using Ambev.Tech.DeveloperStore.Application.Carts.Commands;

    namespace Application.Carts.Handlers;

    public class UpdateCartHandler : IRequestHandler<UpdateCartCommand>
    {
        private readonly ICartRepository _cartRepository;

        public UpdateCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(request.Id);

            if (cart == null)
                throw new NotFoundException("Cart not found");

            cart.Products = request.Products.Select(p => new CartItem
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList();

            await _cartRepository.UpdateAsync(cart);
            return Unit.Value;
        }
    }
}
