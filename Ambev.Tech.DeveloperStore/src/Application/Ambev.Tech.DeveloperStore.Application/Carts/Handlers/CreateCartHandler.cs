using Ambev.Tech.DeveloperStore.Application.Carts.Commands;
using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using Ambev.Tech.DeveloperStore.Application.Interface;
using Ambev.Tech.DeveloperStore.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Carts.Handlers
{
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, CartDto>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        public CreateCartHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CartDto> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = new Cart
            {
                UserId = request.CartDto.Id,
                Date = request.CartDto.Date,
                Items = request.CartDto.Items.Select(p => new CartItem
                {
                    ProductId = p.ProductId,
                    Quantity = p.Quantity
                }).ToList()
            };

            var createdCart = await _cartRepository.AddAsync(cart);
            return _mapper.Map<CartDto>(createdCart);
        }
    }
}
